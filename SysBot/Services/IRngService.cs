namespace SysBot.Services;

internal interface IRngService
{
    string GetRandomNumber(int limiter);
}