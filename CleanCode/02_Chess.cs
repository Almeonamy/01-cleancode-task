namespace CleanCode
{
	public class Chess
	{
		private readonly Board b;

		public Chess(Board b)
		{
		    this.b = b;
		}

		public string GetWhiteStatus() {
			bool bad = CheckForWhite();
			bool ok =  false;
			foreach (var loc1 in b.Figures(Cell.White))
			{
				foreach (var loc2 in b.Get(loc1).Figure.Moves(loc1, b)){
				var oldDest = b.PerformMove(loc1, loc2);
				    if (!CheckForWhite())
				    {
				        ok = true;
				    }
				    b.PerformUndoMove(loc1, loc2, oldDest);
				}
			}
		    if (bad)
		    {
		        return ok ? "check" : "mate";
		    }
		    return "stalemate";
		}

		private bool CheckForWhite()
		{
			bool bFlag = false;
			foreach (var loc in b.Figures(Cell.Black))
			{
				var cell = b.Get(loc);
				var moves = cell.Figure.Moves(loc, b);
				foreach (var to in moves)
				{
					if (b.Get(to).IsWhiteKing)
						bFlag = true;
				}
			}
		    return bFlag;
		}
	}
}