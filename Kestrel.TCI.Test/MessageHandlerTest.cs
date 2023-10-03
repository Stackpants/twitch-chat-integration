using Kestrel.TCI.Application;


namespace Kestrel.TCI.Test;

[TestClass]
public class MessageHandlerTest
{

    [TestMethod]
    public async Task TestWriter()
    {
        IMessageHandler sut = new FileWriteMessageHandler();
        await sut.HandleMessage("TEST");
        await sut.HandleMessage("TEST");
        await sut.HandleMessage("TEST");
        await sut.HandleMessage("TESTsss");
    }
    
    
    
}
