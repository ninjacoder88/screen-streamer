// See https://aka.ms/new-console-template for more information
using ScreenStreamerServer.Strategy;

Console.WriteLine("Staring");

new SerializerV1().Serialize("");
new SerializerV2().Serialize("");

Console.WriteLine("Finished");
