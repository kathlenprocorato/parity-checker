using ParityCheckerApp;

class Program
{
    static void Main()
    {
        ParityChecker checker = new ParityChecker();

        int[] bits = { 1, 0, 1, 1, 0, 1 };
        string parity = checker.GetParity(bits);
        Console.WriteLine("Parity: " + parity);
        bool hasError = checker.CheckError(bits, "EVEN");
        Console.WriteLine("Has Error: " + hasError);

        int[][] blocks = new int[3][]
        {
            new int[] { 1, 0, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 1, 1, 0 }
        };
        int[] bcc = checker.CalculateBCC(blocks);
        Console.WriteLine("Calculated BCC: " + string.Join("", bcc));
        bool hasBCCError = checker.CheckErrorWithBCC(blocks, bcc);
        Console.WriteLine("Has BCC Error: " + hasBCCError);

        int[][] blocksWithParity = new int[3][]
        {
            new int[] { 1, 0, 1 },
            new int[] { 0, 1, 1 },
            new int[] { 1, 1, 0 }
        };
        string parityType = "ODD";
        int[] bccWithParity = checker.CalculateBCCWithParity(blocksWithParity, parityType);
        Console.WriteLine("Calculated BCC with " + parityType + " parity: " + string.Join("", bccWithParity));
    }
}