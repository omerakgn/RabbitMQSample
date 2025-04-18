using System.Text;
using System.Threading.Tasks;
using RabbitMQSample;
using Newtonsoft.Json;
using RabbitMQ.Client;

public class FormHelper
{

     IConnection connection;
    ConnectionFactory factory = new ConnectionFactory();
    private readonly string CreateDocument = "create_document_queue";
    private readonly string documentCreated = "document_created_queue";
    private readonly string documentCreateExchange = "document_create_exchange";

    IChannel _channel;

   
    
    private Form1 _form;
    public FormHelper(Form1 form){

        _form = form;
    }

    public async void ButtonClickHandler(object? sender, EventArgs e){

        _channel = await GetChannel();
        await Binding();

    }
    public async void ButtonDocumentClickHandler(object? sender, EventArgs e){
       
       var model = new CreateDocumentModel(){
        UserId = 1,
        DocumentType= DocumentType.Pdf
       };
       await WriteToQueue(CreateDocument,model);
       MessageBox.Show("çalıştı");
    }

    private async Task<IChannel> GetChannel(){

        connection = await factory.CreateConnectionAsync();
        
        return await connection.CreateChannelAsync();
       
    }
    private async Task Binding(){

        await _channel.ExchangeDeclareAsync(documentCreateExchange, ExchangeType.Direct);
        await _channel.QueueDeclareAsync(CreateDocument, false, false, false, null);
        await _channel.QueueBindAsync(CreateDocument,documentCreateExchange, CreateDocument);
    }


    public async Task WriteToQueue(string queueName, CreateDocumentModel model){
        var MessageArr = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
        var props = new BasicProperties();
      
        await _channel.BasicPublishAsync(documentCreateExchange, queueName, true, props,MessageArr);


    }
}