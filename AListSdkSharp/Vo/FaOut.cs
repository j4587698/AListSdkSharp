namespace AListSdkSharp.Vo
{
    public class FaOut: Base
    {
        public FaData Data { get; set; }
        
        public class FaData
        {
            public string Qr { get; set; }

            public string Secret { get; set; }
        }
    }
}