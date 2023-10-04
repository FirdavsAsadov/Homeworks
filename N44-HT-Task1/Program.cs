using N44_HT_Task1;

var cancellationToken = new CancellationTokenSource(5000);
try
{
    await CancellationTokenService.Execution(cancellationToken.Token);
}
catch (Exception ex)
{
    Console.WriteLine("Exeption!!!");
}