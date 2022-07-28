// See https://aka.ms/new-console-template for more information
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using aws_buskets_app;

try
{
    Console.WriteLine("Hello, World!");

    var s3Client = new AmazonS3Client(Constants.UID, Constants.Secret, RegionEndpoint.EUCentral1); // Frankfurt

    string path = "C:/Users/user/Desktop/deneme.png";

    string generateFileLink = "https://fiplatfom-mp.s3.eu-central-1.amazonaws.com/";

    #region S3 Buckets List

    //var buckets = await s3Client.ListBucketsAsync(); //Bucket List
    //Console.WriteLine(string.Join(",", buckets.Buckets.Select(x => x.BucketName)));

    #endregion

    #region S3 Buckets in List

    //var objects = await s3Client.ListObjectsAsync("fiplatfom-mp");

    //if (objects != null)
    //    Console.WriteLine(string.Join(",", objects.S3Objects.Select(x => x.Key)));

    #endregion

    #region Sample 1 

    //using (var fs = new FileStream(path, FileMode.Create))
    //{
    //    MemoryStream inputStream = new MemoryStream();

    //    string key = "serif-deneme-png.png";

    //    var putRequest = new PutObjectRequest
    //    {
    //        BucketName = "fiplatfom-mp",
    //        Key = key,
    //        InputStream = fs,
    //        ContentType = "image/png",
    //    };

    //    PutObjectResponse response = s3Client.PutObjectAsync(putRequest).Result;
    //}
    #endregion

    #region Sample 2
    //try
    //{
    //    FileStream fs = new FileStream(path, FileMode.Open);
    //    byte[] buffer = new byte[fs.Length];
    //    fs.Read(buffer, 0, buffer.Length);

    //    MemoryStream inputStream = new MemoryStream();
    //    inputStream.Write(buffer, 0, buffer.Length);

    //    var upload = new TransferUtilityUploadRequest()
    //    {
    //        InputStream = inputStream,
    //        Key = "serif-transfer-example-00000000-1111111.png",
    //        BucketName = "fiplatfom-mp",
    //        CannedACL = S3CannedACL.PublicRead
    //    };

    //    var fileTransferUtility = new TransferUtility(s3Client);
    //    await fileTransferUtility.UploadAsync(upload);
    //}
    //catch (AmazonS3Exception ex)
    //{
    //    Console.WriteLine(ex.ErrorCode);
    //    Console.WriteLine(ex.Message);
    //}
    #endregion

    #region AWS S3 image created

    FileStream fs = new FileStream(path, FileMode.Open);
    byte[] buffer = new byte[fs.Length];
    fs.Read(buffer, 0, buffer.Length);

    MemoryStream inputStream = new MemoryStream();
    inputStream.Write(buffer, 0, buffer.Length);

    string key = "ficommerceImages/customer-uid.png"; //Generator File Name

    var putRequest = new PutObjectRequest
    {
        BucketName = Constants.Bucket,
        Key = key,
        InputStream = inputStream,
        ContentType = "image/png"
    };

    PutObjectResponse response = s3Client.PutObjectAsync(putRequest).Result;
    generateFileLink += key;

    Console.WriteLine(generateFileLink); //Database created file name

    #endregion

    #region AWS S3 image deleted

    DeleteObjectRequest deleteRequest = new DeleteObjectRequest
    {
        BucketName = Constants.Bucket,
        Key = "serif-deneme-png.png"
    };

    var response = s3Client.DeleteObjectAsync(deleteRequest).Result;

    #endregion

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}