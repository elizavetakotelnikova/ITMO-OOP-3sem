using System;
using System.Drawing;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.DisplayDirectory;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.MessengerDirectory;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessagesTests
{
    [Fact]
    public void MessagePassedToUserShouldReturnUnread()
    {
        var firstUser = new User(200);
        var userReceiver = new UserReceiver(firstUser);
        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(1).Build();
        var proxyAddressee = new ProxyAddressee(userReceiver);
        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();
        MessageWithInfo deliveredMessage = firstUser.MessageInfo.First(elem => elem.Message == firstMessage);
        Assert.True(deliveredMessage.IsRead == false);
    }

    [Fact]
    public void MessagePassedToUserTryToMakeReadShouldReturnReadStatus()
    {
        var firstUser = new User(200);
        var userReceiver = new UserReceiver(firstUser);
        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(1).Build();
        var proxyAddressee = new ProxyAddressee(userReceiver);
        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();
        firstUser.SetRead(firstMessage);
        MessageWithInfo deliveredMessage = firstUser.MessageInfo.First(elem => elem.Message == firstMessage);
        Assert.True(deliveredMessage.IsRead);
    }

    [Fact]
    public void MessagePassedToUserTryToMakeMarkedAsReadShouldReturnError()
    {
        var firstUser = new User(200);
        var userReceiver = new UserReceiver(firstUser);
        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(1).Build();
        var proxyAddressee = new ProxyAddressee(userReceiver);
        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();
        firstUser.SetRead(firstMessage);
        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(() => firstUser.SetRead(firstMessage));
        Assert.Equal("Message is already read", exception.Message);
    }

    [Fact]
    public void MessagePassedToUserLowPriorityShouldDeliverOnlyOnce()
    {
        var addresseeMock = new Mock<ISendToConcreteAddressee>();
        ISendToConcreteAddressee addresseeClient = addresseeMock.Object;
        var firstUser = new User(200);
        var userReceiver = new UserReceiver(firstUser);
        var display = new Display();
        var displayDriver = new DriverDisplay(display, Color.Gold, Color.Chartreuse);

        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(2).Build();

        var proxyAddressee = new ProxyAddressee(addresseeClient, 3);
        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();

        Message secondMessage = messageBuilder.WithHeading("Productive morning")
            .WithMainPart("Hello, colleagues! Wish you a pleasant day.")
            .WithImportanceLevel(4).Build();

        // proxyAddressee.Addressee = new DisplayReceiver(displayDriver);
        meetingsTopic.GetMessage(secondMessage);
        meetingsTopic.SendLastMessage();
        addresseeMock.Verify(x => x.SendMessage(firstMessage), Times.Never);
        addresseeMock.Verify(x => x.SendMessage(secondMessage), Times.Once);
    }

    [Fact]
    public void MessagePassedToMessengerShouldBeLogged()
    {
        var firstUser = new User(200);
        var userReceiver = new UserReceiver(firstUser);
        var proxyMock = new Mock<ProxyAddressee>(userReceiver);
        ProxyAddressee proxyAddressee = proxyMock.Object;
        var messenger = new Messenger();

        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(2).Build();

        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();

        Message secondMessage = messageBuilder.WithHeading("Productive morning")
            .WithMainPart("Hello, colleagues! Wish you a pleasant day.")
            .WithImportanceLevel(4).Build();

        proxyAddressee.Addressee = new MessengerReceiver(messenger);
        proxyAddressee.ShouldBeLogged = true;
        meetingsTopic.GetMessage(secondMessage);
        meetingsTopic.SendLastMessage();
        proxyMock.Verify(x => x.WriteNewMessageLog(), Times.Once);
    }

    [Fact]
    public void MessagePassedToMessengerShouldDisplay()
    {
        var messengerMock = new Mock<Messenger>();
        Messenger messenger = messengerMock.Object;
        var messengerReceiver = new MessengerReceiver(messenger);
        var proxyAddressee = new ProxyAddressee(messengerReceiver);

        var messageBuilder = new MessageBuilder();
        Message firstMessage = messageBuilder.WithHeading("New meeting on Saturday")
            .WithMainPart("Hello, colleagues! On Saturday we will have a common meeting at 20.00")
            .WithImportanceLevel(2).Build();

        var meetingsTopic = new Topic("Meetings", proxyAddressee);
        meetingsTopic.GetMessage(firstMessage);
        meetingsTopic.SendLastMessage();

        Message secondMessage = messageBuilder.WithHeading("Productive morning")
            .WithMainPart("Hello, colleagues! Wish you a pleasant day.")
            .WithImportanceLevel(4).Build();

        proxyAddressee.ShouldBeLogged = true;
        meetingsTopic.GetMessage(secondMessage);
        meetingsTopic.SendLastMessage();
        messengerMock.Verify(x => x.DisplayMessage(firstMessage), Times.Once);
        messengerMock.Verify(x => x.DisplayMessage(secondMessage), Times.Once);
    }
}