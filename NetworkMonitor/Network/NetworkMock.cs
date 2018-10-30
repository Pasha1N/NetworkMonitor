using System;
using System.Threading.Tasks;

namespace NetworkMonitor.Services
{
    internal sealed class NetworkMock : INetwork
    {
        private const int BytesPerKilobyte = 1024;
        private const int BytesPerMegabyte = BytesPerKilobyte * 1024;
        private const double DataSizeChangeCoefficient = 1.15;

        private static readonly TimeSpan dataSizeChangeInterval = TimeSpan.FromMilliseconds(300.0);

        private readonly int dataSizeMaximum;
        private readonly int dataSizeMinimum;
        private readonly TimeSpan delayMaximum;
        private readonly TimeSpan delayMinimum;
        private readonly Random random = new Random();

        private int dataSize;
        private DateTime previousDataSizeChangeTimestamp = DateTime.Now;

        public NetworkMock() :
            this(dataSizeMinimum: 10 * BytesPerKilobyte, dataSizeMaximum: 20 * BytesPerMegabyte)
        {
        }

        public NetworkMock(int dataSizeMinimum, int dataSizeMaximum) :
            this(dataSizeMinimum, dataSizeMaximum, delayMinimum: TimeSpan.FromMilliseconds(100.0), delayMaximum: TimeSpan.FromMilliseconds(200.0))
        {
        }

        public NetworkMock(int dataSizeMinimum, int dataSizeMaximum, TimeSpan delayMinimum, TimeSpan delayMaximum)
        {
            this.dataSizeMaximum = dataSizeMaximum;
            this.dataSizeMinimum = dataSizeMinimum;
            this.delayMaximum = delayMaximum;
            this.delayMinimum = delayMinimum;

            dataSize = random.Next(dataSizeMinimum, dataSizeMaximum);
        }

        private int CalculateDataSize(TimeSpan delay)
        {
            return (int)(delay.TotalMilliseconds * dataSize / delayMaximum.TotalMilliseconds);
        }

        private void ChangeDataSize()
        {
            DateTime currentTimestamp = DateTime.Now;

            TimeSpan interval = currentTimestamp - previousDataSizeChangeTimestamp;
            if (interval > dataSizeChangeInterval)
            {
                if (random.Next(2) == 0)
                {
                    dataSize = (int)(dataSize * DataSizeChangeCoefficient);
                }
                else
                {
                    dataSize = (int)(dataSize / DataSizeChangeCoefficient);
                }

                if (dataSize < dataSizeMinimum)
                {
                    dataSize = dataSizeMinimum;
                }
                if (dataSize > dataSizeMaximum)
                {
                    dataSize = dataSizeMaximum;
                }

                previousDataSizeChangeTimestamp = currentTimestamp;
            }
        }

        private byte[] GenerateData(int dataSize)
        {
            return new byte[dataSize];
        }

        public Task<byte[]> GetDataAsync()
        {
            TimeSpan delay = TimeSpan.FromMilliseconds(
                random.Next((int)delayMinimum.TotalMilliseconds, (int)delayMaximum.TotalMilliseconds)
            );

            return Task
                .Delay(delay)
                .ContinueWith(previousTask => ChangeDataSize())
                .ContinueWith(previousTask => CalculateDataSize(delay))
                .ContinueWith(previousTask => GenerateData(previousTask.Result));
        }
    }
}