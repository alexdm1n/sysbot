namespace SysBot.Services;

internal class RngService : IRngService
{
    public string GetRandomNumber(int limiter)
    {
        var rnd = new Random();
        return rnd.Next(limiter).ToString();
    }
}