﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameLevel;
using GameLevelLibrary.Models;

namespace LevelPropertyEditor {
	/// <summary>
	/// Окно для вывода списка объектов и 
	/// </summary>
	public partial class MainWindow : Window {
		
		private IAssemblyBehaviourManager m_AssemblyBehaviourManager;

		private IGameLevelData m_GameLevelData;

		public MainWindow () {
			InitializeComponent ();


		}
	}
}
