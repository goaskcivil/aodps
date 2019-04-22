using System;

namespace AODPSo
{
    using System.Drawing;

    internal class Player
	{
		public int Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		public string Nickname
		{
			get
			{
				return this.nickname;
			}
			set
			{
				this.nickname = value;
			}
		}

		public Player()
		{
			this.nickname = "";
			this.id = 0;
			this.dealt = 0L;
			this.taken = 0L;
			this.healed = 0L;
		}

		public Player(string nickname, int id)
		{
			this.nickname = nickname;
			this.id = id;
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				string.Concat(new object[]
				{
					this.nickname,
					"(",
					this.id,
					") "
				}).PadRight(30),
				"D:",
				this.dealt.ToString().PadRight(10),
				" T:",
				this.taken.ToString().PadRight(10),
				" H:",
				this.healed.ToString().PadRight(10)
			});
		}

	    public Color color;

		public long dealt;

		public long healed;

	    public long DPS;

		private int id;

		private string nickname;

		public long self;

		public long taken;
	}
}
