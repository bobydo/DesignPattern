using J5S2EscapeRoom;

List<int> initialized = new List<int> { 3, 10, 8, 14, 1, 11, 12, 12, 6, 2, 3, 9 };

//var result = Console.ReadLine();
//int[] numbers = result.Split(' ');

int[,] array = new int[3, 4];
int rows = array.GetLength(0);
int cols = array.GetLength(1);
int count = 0;
for (int row = 0; row< rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        array[row, col] = initialized[count];
        count++;
    }    
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        bool escaped = escapedOrNot(array, rows, cols, row, col, array[row, col]);
        if (escaped)
            break;
    }
}

static bool escapedOrNot(int[,] array, int rows, int cols, int row, int col,int target)
{
    Console.WriteLine($"target value = {target}");
    if (target == array[rows - 1, cols - 1])
    {
        Console.WriteLine($"target value = {target} and is equal to array[{rows},{cols}] value, so escaped");
        return true;
    }
    List<Tuple<int, int>> combinations = CombinationGenerator.FindCombinations(target);
    foreach (Tuple<int, int> getCom in combinations)
    {
        if (getCom.Item1 > rows || getCom.Item2 > cols)
        {
            Console.WriteLine($"Not possible on {getCom.Item1} x {getCom.Item2}");
            continue;
        }
        else
        {
            int jumpRow = getCom.Item1 - 1;
            int jumpCol = getCom.Item2 - 1;
            Console.WriteLine($"Jump to {getCom.Item1} x {getCom.Item2} value is {array[jumpRow, jumpCol]}");
            if (jumpRow != row || jumpCol != col)
            {
                return escapedOrNot(array, rows, cols, jumpRow, jumpCol, array[jumpRow, jumpCol]);
            }
        }
    }
    return false;
}

Console.ReadLine();

/*
target value = 3
Jump to 1 x 3 value is 8
target value = 8
Not possible on 1 x 8
Not possible on 8 x 1
Jump to 2 x 4 value is 12
target value = 12
Not possible on 1 x 12
Not possible on 12 x 1
Not possible on 2 x 6
Not possible on 6 x 2
Jump to 3 x 4 value is 9
target value = 9
target value = 9 and is equal to array[3,4] value, so escaped
target value = 1
Jump to 1 x 1 value is 3
target value = 3
Jump to 1 x 3 value is 8
target value = 8
Not possible on 1 x 8
Not possible on 8 x 1
Jump to 2 x 4 value is 12
target value = 12
Not possible on 1 x 12
Not possible on 12 x 1
Not possible on 2 x 6
Not possible on 6 x 2
Jump to 3 x 4 value is 9
target value = 9
target value = 9 and is equal to array[3,4] value, so escaped
target value = 6
Not possible on 1 x 6
Not possible on 6 x 1
Jump to 2 x 3 value is 12
target value = 12
Not possible on 1 x 12
Not possible on 12 x 1
Not possible on 2 x 6
Not possible on 6 x 2
Jump to 3 x 4 value is 9
target value = 9
target value = 9 and is equal to array[3,4] value, so escaped
 */

