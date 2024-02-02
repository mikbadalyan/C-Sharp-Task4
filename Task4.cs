//Task 4

//Շախմատի տախտակի ստեղծում։
int rows = 8;
int columns = 8;
int quant = 0;
int[,] chess_board = new int[rows, columns];

Console.WriteLine("Please wait up to 5 seconds to see the results...");
Console.WriteLine("Loading...");

//

while (quant < 60)
{
    quant = 0;   
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            chess_board[i, j] = 0;
        }
    } 
    //Ստեղծում ենք rand անունով զանգված, որի զույգ էլեմենտների վրա կպահենք տողերի ինդեքսը, իսկ կենտ էլեմենտների վրա սյուների ինդեքսը։
    int[] rand = new int[16];
    int num = 0;
    //
    Knight knight1 = new Knight();
    //Ստեղծում ենք knight1 անունով օբյեկտ, որը կունենա նախնական դիրք շախմատի տախտակի վրա (5,6)։
    knight1.knight_row = 5;
    knight1.knight_column = 6;
    knight1.knight_strokes(chess_board, knight1.knight_row, knight1.knight_column, rand, num);
    knight1.knight_strokes_cleaner(chess_board, knight1.knight_row, knight1.knight_column);
    
    quant++;



    //

    // Քայլ է կատարում հաջորդ հավանական վայրերից մեկում, պատահականության սկզբունքով։
    Random random = new Random();

    for (int i = 0; i < 20000; i++)
    {
        int m = random.Next(0,15);
        //Console.WriteLine(m);
        if (m % 2 == 0 && (rand[m] != -1 || rand[m+1] != -1))
        {
            Knight knight2 = new Knight();
            knight2.knight_row = rand[m];
            knight2.knight_column = rand[m + 1];
            knight2.knight_strokes_cleaner(chess_board, knight2.knight_row, knight2.knight_column);
            num = 0;
            for (int j = 0; j < 16; j++)
            {
                rand[j] = -1;
            }
            //knight2.knight_strokes_cleaner(chess_board, knight2.knight_row, knight2.knight_column);
            knight2.knight_strokes(chess_board, knight2.knight_row, knight2.knight_column, rand, num);
            knight2.knight_strokes_cleaner(chess_board, knight2.knight_row, knight2.knight_column);
           
            quant++;


        }else if (m % 2 != 0 && (rand[m-1] != -1 || rand[m] != -1))
        {
            Knight knight2 = new Knight();
            knight2.knight_row = rand[m - 1];
            knight2.knight_column = rand[m];
            knight2.knight_strokes_cleaner(chess_board, knight2.knight_row, knight2.knight_column);
            num = 0;
            for (int j = 0; j < 16; j++)
            {
                rand[j] = -1;
            }
            
            knight2.knight_strokes(chess_board, knight2.knight_row, knight2.knight_column, rand, num);
            knight2.knight_strokes_cleaner(chess_board, knight2.knight_row, knight2.knight_column);
           
            quant++;
        }
        
    }

    
    //
    
    //Ստեղծում ենք Knight անունով class-ը, որը իր մեջ կներառի տվյալներ շախմատի ձիու մասին, նրա հնարավոր քայլերի ինչպես նաև վիզուալ պատկերը իր մեջ։ Վերջում նոր քայլ անելից կարող ենք ջնջել նախորդ դիրքերի 1֊երը։

}
Knight knight3 = new Knight();
knight3.visual(rows, columns, chess_board);
Console.WriteLine(quant);
class Knight
{
    public int knight_row;
    public int knight_column;

    public Knight()
    {
        
    }

    /// <summary>
    /// Այս ֆունկցիան շախմատի դիրքերին տալիս է 1 արժեք եթե ձին կարող է այնտեղ քայլ կատարել։
    /// </summary>
    /// <param name="chess_board">Շախմատի տախտակ, մատրից</param>
    /// <param name="knight_row">Ձիու գտնվելու տողի ինդեքսը</param>
    /// <param name="knight_column">Ձիու գտվելու սյան ինդեքսը</param>
    /// <param name="rand">Զանգված ոռը իր մեջ պահում է հավնական քայլերի՝ դիրքերի, կոորդինատները</param>
    /// <param name="num">Փոփոխանական որով դասավորում ենք էլեմենտները rand զանգվածում</param>
    public void knight_strokes(int[,] chess_board, int knight_row, int knight_column, int[] rand, int num)
    {
        for (int i = 1; i < 3; i++)
        {
            int j = 3 - i;
            if (knight_row + i <= 7 && knight_column + j <= 7 && chess_board[knight_row + i, knight_column + j] != 9)
            {
                chess_board[knight_row + i, knight_column + j] = 1;
                rand[num] = knight_row + i;
                rand[num + 1] = knight_column + j;
                num = num + 2;
            }
            if (knight_row + i <= 7 && knight_column - j >= 0 && chess_board[knight_row + i, knight_column - j] != 9)
            {
                chess_board[knight_row + i, knight_column - j] = 1;
                rand[num] = knight_row + i;
                rand[num + 1] = knight_column - j;
                num = num + 2;    
            }
            if (knight_row - i >= 0 && knight_column - j >= 0 && chess_board[knight_row - i, knight_column - j] != 9)
            {
                chess_board[knight_row - i, knight_column - j] = 1;
                rand[num] = knight_row - i;
                rand[num + 1] = knight_column - j;
                num = num + 2;    
            }
            if (knight_row - i >= 0 && knight_column + j <= 7 && chess_board[knight_row - i, knight_column + j] != 9)
            {
                chess_board[knight_row - i, knight_column + j] = 1;
                rand[num] = knight_row - i;
                rand[num + 1] = knight_column + j;
                num = num + 2;    
            }
        
        }
        chess_board[knight_row, knight_column] = 9;
    }

    public int quantity = 0;
    /// <summary>
    /// Վիզուալ շախմատի տախտակի պատկեր
    /// </summary>
    /// <param name="rows">տողերի քանակ</param>
    /// <param name="columns">սյան քանակ</param>
    /// <param name="chess_board">Շախմատի տախտակ, համապատասխանաբար մատրից</param>
    public void visual(int rows, int columns, int[,] chess_board)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (chess_board[i, j] == 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(chess_board[i, j] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    quantity++;
                }
                else
                {
                    Console.Write(chess_board[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine(quantity);
        Console.WriteLine();
        Console.WriteLine();
    }
    
    
    /// <summary>
    /// Քայլ անելուց հետո մաքրում է բոլոր նախորդ 1 արժեքները։
    /// </summary>
    /// <param name="chess_board">Շախմատի տախտակ</param>
    /// <param name="knight_row">Ձիու տողի կոորդինատ</param>
    /// <param name="knight_column">Ձիու սյան կոորդինատ</param>
    public void knight_strokes_cleaner(int[,] chess_board, int knight_row, int knight_column)
    {
        for (int i = 1; i < 3; i++)
        {
            int j = 3 - i;
            if (knight_row + i <= 7 && knight_column + j <= 7 && chess_board[knight_row + i, knight_column + j] != 9)
            {
                chess_board[knight_row + i, knight_column + j] = 0;
                
            }
            if (knight_row + i <= 7 && knight_column - j >= 0 && chess_board[knight_row + i, knight_column - j] != 9)
            {
                chess_board[knight_row + i, knight_column - j] = 0;
                    
            }
            if (knight_row - i >= 0 && knight_column - j >= 0 && chess_board[knight_row - i, knight_column - j] != 9)
            {
                chess_board[knight_row - i, knight_column - j] = 0;
                
            }
            if (knight_row - i >= 0 && knight_column + j <= 7 && chess_board[knight_row - i, knight_column + j] != 9)
            {
                chess_board[knight_row - i, knight_column + j] = 0;
                 
            }
        
        }
    }
}

