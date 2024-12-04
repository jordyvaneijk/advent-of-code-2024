namespace AocDay4;

public class Puzzle
{
    public char[][] Input { get; set; }

    public CountReport CountOccurrences(string target)
    {
        int totalCount = 0;
        int horizontalCount = 0;
        int verticalCount = 0;
        int diagonalCount = 0;
        int specialPatternCount = 0;
        int rows = Input.Length;
        int cols = Input[0].Length;
        int targetLength = target.Length;

        // Check horizontally and vertically
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Left to right
                if (j <= cols - targetLength && CheckDirection(i, j, 0, 1, target))
                {
                    totalCount++;
                    horizontalCount++;
                }

                // Right to left
                if (j >= targetLength - 1 && CheckDirection(i, j, 0, -1, target))
                {
                    totalCount++;
                    horizontalCount++;
                }

                // Top to bottom
                if (i <= rows - targetLength && CheckDirection(i, j, 1, 0, target))
                {
                    totalCount++;
                    verticalCount++;
                }

                // Bottom to top
                if (i >= targetLength - 1 && CheckDirection(i, j, -1, 0, target))
                {
                    totalCount++;
                    verticalCount++;
                }

                // Diagonal down-right
                if (i <= rows - targetLength && j <= cols - targetLength && CheckDirection(i, j, 1, 1, target))
                {
                    totalCount++;
                    diagonalCount++;
                }

                // Diagonal up-left
                if (i >= targetLength - 1 && j >= targetLength - 1 && CheckDirection(i, j, -1, -1, target))
                {
                    totalCount++;
                    diagonalCount++;
                }

                // Diagonal down-left
                if (i <= rows - targetLength && j >= targetLength - 1 && CheckDirection(i, j, 1, -1, target))
                {
                    totalCount++;
                    diagonalCount++;
                }

                // Diagonal up-right
                if (i >= targetLength - 1 && j <= cols - targetLength && CheckDirection(i, j, -1, 1, target))
                {
                    totalCount++;
                    diagonalCount++;
                }

                // Special pattern
                if (CheckSpecialPattern(i, j))
                {
                    totalCount++;
                    specialPatternCount++;
                }
            }
        }

        return new CountReport(totalCount, horizontalCount, verticalCount, diagonalCount, specialPatternCount);
    }

    private bool CheckSpecialPattern(int startX, int startY)
    {
        if (startX + 2 < Input.Length && startY + 2 < Input[0].Length)
        {
            // Left-top to right-bottom
            if (Input[startX][startY] == 'M' &&
                Input[startX][startY + 2] == 'S' &&
                Input[startX + 1][startY + 1] == 'A' &&
                Input[startX + 2][startY] == 'M' &&
                Input[startX + 2][startY + 2] == 'S')
            {
                return true;
            }
        }

        if (startX - 2 >= 0 && startY - 2 >= 0)
        {
            // Right-bottom to left-top
            if (Input[startX][startY] == 'M' &&
                Input[startX][startY - 2] == 'S' &&
                Input[startX - 1][startY - 1] == 'A' &&
                Input[startX - 2][startY] == 'M' &&
                Input[startX - 2][startY - 2] == 'S')
            {
                return true;
            }
        }

        if (startX + 2 < Input.Length && startY - 2 >= 0)
        {
            // Left-bottom to right-top
            if (Input[startX][startY] == 'M' &&
                Input[startX][startY - 2] == 'S' &&
                Input[startX + 1][startY - 1] == 'A' &&
                Input[startX + 2][startY] == 'M' &&
                Input[startX + 2][startY - 2] == 'S')
            {
                return true;
            }
        }

        if (startX - 2 >= 0 && startY + 2 < Input[0].Length)
        {
            // Right-top to left-bottom
            if (Input[startX][startY] == 'M' &&
                Input[startX][startY + 2] == 'S' &&
                Input[startX - 1][startY + 1] == 'A' &&
                Input[startX - 2][startY] == 'M' &&
                Input[startX - 2][startY + 2] == 'S')
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckDirection(int startX, int startY, int dx, int dy, string target)
    {
        for (int k = 0; k < target.Length; k++)
        {
            if (Input[startX + k * dx][startY + k * dy] != target[k])
            {
                return false;
            }
        }

        return true;
    }
}