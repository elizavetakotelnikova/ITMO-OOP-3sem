using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Receiver;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
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
        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(() => firstUser.SetRead(firstMessage));
        Assert.Equal("Message is already read", exception.Message);
    }

    [Fact]
    public void MessagePassedToUserLowPriorityShouldDeliverOnlyOnce()
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
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => firstUser.SetRead(firstMessage));
        Assert.Equal("Message is already read", exception.Message);
    }
}