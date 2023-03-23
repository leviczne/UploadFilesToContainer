using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;


Console.WriteLine("Aprendendo a mandar arquivos pro blob\n");

// Run the examples asynchronously, wait for the results before proceeding
ProcessAsync().GetAwaiter().GetResult();

Console.WriteLine("Press enter to exit the sample application.");
Console.ReadLine();

static async Task ProcessAsync()
{
 
    string storageConnectionString = "connectionString";
    var blobStorageContainerName = "testecriandocontainerpelocodigo";

    var container = new BlobContainerClient(storageConnectionString, blobStorageContainerName);

  
    var files = Directory.GetFiles(@"C:\Users\levi.santos\blob");
    foreach (var file in files)
    {
        using (FileStream uploadFileStream = File.OpenRead(file))
        {
            BlobClient blobClient = container.GetBlobClient(file);
            await blobClient.UploadAsync(uploadFileStream);

            Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);
            uploadFileStream.Close();
        }
        Console.WriteLine("O arquivo foi updado{0}",file);
    }
    foreach(var file in files)
    { //deleta os arquivos da pagina
        File.Delete(file);
        Console.WriteLine("O arquivo {0} foi deletado",file);
    }
    Console.WriteLine("\nThe file was uploaded. We'll verify by listing" +
            " the blobs next.");
    Console.WriteLine("Press 'Enter' to continue.");
    Console.ReadLine();

}