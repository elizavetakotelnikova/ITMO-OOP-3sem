using Crayon;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var display = new Display();
        var displayDriver = new DriverDisplay(display, Output.Yellow(), Output.Cyan());
        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(1).Build();
        var proxyAddressee = new ProxyAddressee(new DisplayReceiver(displayDriver));
        proxyAddressee.ShouldBeLogged = true;
        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();
    }
}