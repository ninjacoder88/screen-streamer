// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Starting");

IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 42069);

UdpClient udpClient = new UdpClient(42069);
Console.WriteLine("Listening");

while(true)
{
    try
    {
        byte[] array = udpClient.Receive(ref iPEndPoint);
        Console.WriteLine($"Received {array.Length} bytes");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}