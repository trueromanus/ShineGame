using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShineGameEditor;

namespace Prisoner {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main ( string[] args ) {
			using ( PrisonerGame game = new PrisonerGame ( args.Contains ( "-windowed" ) , args.Contains ( "-developer" ) ) ) {
				game.Run ();
			}
		}
	}
}
