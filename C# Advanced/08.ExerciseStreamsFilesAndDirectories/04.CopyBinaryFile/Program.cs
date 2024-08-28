namespace _04.CopyBinaryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (FileStream fileStreamReader = new FileStream("../../../copyMe.png", FileMode.Open))
            //{
            //    byte[] buffer = new byte[1024];

            //    using (FileStream fileStreamWrite = new FileStream("../../../NewCopyMe.png", FileMode.Create))
            //    {
            //        int count = 0;
            //        while (fileStreamReader.Read(buffer, 0, buffer.Length) > 0)
            //        {
            //            fileStreamWrite.Write(buffer, 0, buffer.Length);
            //            count++;
            //        }
            //    }
            //}

            using (FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writeStream = new FileStream("../../../newCopyMe.png", FileMode.Create))
                {
                    while (readStream.Position < readStream.Length)
                    {
                        byte[] buffer = new byte[4096];
                        int count = readStream.Read(buffer, 0, buffer.Length);

                        //if (count == 0)
                        //{
                        //    break;
                        //}

                        writeStream.Write(buffer, 0, count);
                    }
                }
            }
        }
    }
}
