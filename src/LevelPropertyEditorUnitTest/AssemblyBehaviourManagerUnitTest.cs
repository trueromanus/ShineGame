using System;
using System.Linq;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using LevelPropertyEditor;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LevelPropertyEditor.Implementation;

namespace LevelPropertyEditorUnitTest {

	/// <summary>
	/// Тесты для реализаций интерфейса <see cref="IAssemblyBehaviourManager"/>.
	/// </summary>
	[TestClass]
	public class AssemblyBehaviourManagerUnitTest {

		private const string TestAssemblyName = "Тестовая сборка";

		private const string TestAssemblyDescription = "Описание тестовой сборки";

		private const string TestAssemblyEventDescription = "Тестовое описание события";

		private const string TestAssemblyStateDescription = "Тестовое описание состояния";

		private const string TestAssemblyActionDescription = "Тестовое описание действия";

		private const string TestAssemblyEventName = "Event";

		private const string TestAssemblyStateName = "State";

		private const string TestAssemblyActionName = "Action";

		private const string TestBehaviourName = "Behaviour";

		private const string TestBehaviourDescription = "BehaviourDescription";

		/// <summary>
		/// Получить исходный код для тестовой сборки поведений.
		/// </summary>
		/// <returns>Исходный код для тестовой сборки поведений</returns>
		private string GetSoureCodeTestAssembly () {
			return
				"using System;" +
				"using AbstractGameLogic;" +
				"using AbstractGameLogic.Attributes;" +
				"[assembly: AssemblyBehaviour ( Name = \"" + TestAssemblyName + "\" , Description = \"" + TestAssemblyDescription + "\" )]" +
				"namespace TestAssembly{" +
					"[GameEvent ( Name = \"" + TestAssemblyEventName + "\" , Description = \"" + TestAssemblyEventDescription + "\" )]" +
					"[GameState ( Name = \"" + TestAssemblyStateName + "\" , Description = \"" + TestAssemblyStateDescription + "\" )]" +
					"[GameAction ( Name = \"" + TestAssemblyActionName + "\" , Description = \"" + TestAssemblyActionDescription + "\" )]" +
					"[ObjectBindBehaviour ( Name = \"" + TestBehaviourName + "\" , Description = \"" + TestBehaviourDescription + "\" )]" +
					"public class TestClass{" +
					"}" +
				"}"

			;
		}

		/// <summary>
		/// Создать тестовую сборку.
		/// </summary>
		/// <returns>Тестовая сборка.</returns>
		private Assembly CreateAssembly () {
			using ( CSharpCodeProvider codeProvider = new CSharpCodeProvider () ) {
				var nameAssembly = Path.Combine ( Path.GetDirectoryName ( Assembly.GetExecutingAssembly ().Location ) , "TestAssembly.dll" );
				var parameters = new CompilerParameters {
					GenerateExecutable = false ,
					IncludeDebugInformation = true ,
					OutputAssembly = nameAssembly
				};
				parameters.ReferencedAssemblies.Add ( "mscorlib.dll" );
				parameters.ReferencedAssemblies.Add ( "AbstractGameLogic.dll" );
				var result = codeProvider.CompileAssemblyFromSource (
					parameters ,
					new List<string> {
						GetSoureCodeTestAssembly()
					}
					.ToArray ()
				);
				if ( result.Errors.Count > 0 ) throw new InvalidOperationException ( "Ошибка компиляции тестовой сборки." );

				return result.CompiledAssembly;
			}
		}

		/// <summary>
		/// Проекция данных в сборке.
		/// </summary>
		[TestMethod]
		[Description ( "Проекция данных из сборки." )]
		public void ProjectionDataFromAssembly () {
			IAssemblyBehaviourManager manager = new AssemblyBehaviourManager ();
			manager.AddAssembly ( CreateAssembly () );

			Assert.IsTrue ( manager.Assemblies.Count () == 1 , "Количество сборок некорректно." );
			var model = manager.Assemblies.First ();
			Assert.IsTrue ( model.Name == TestAssemblyName , "Имя сборки некорректна." );
			Assert.IsTrue ( model.Description == TestAssemblyDescription , "Описание сборки некорректно." );
			Assert.IsTrue ( model.Behaviours.Count () == 1 , "Количество поведений некорректно." );
			var behaviour = model.Behaviours.First ();
			var action = behaviour.Actions.First ();
			var @event = behaviour.Events.First ();
			var states = behaviour.States.First ();
			Assert.IsTrue ( action.Name == TestAssemblyActionName && action.Description == TestAssemblyActionDescription );
			Assert.IsTrue ( @event.Name == TestAssemblyEventName && @event.Description == TestAssemblyEventDescription );
			Assert.IsTrue ( states.Name == TestAssemblyStateName && states.Description == TestAssemblyStateDescription );
		}

		/// <summary>
		/// Добавление сборок в менеджер.
		/// </summary>
		[TestMethod]
		[Description ( "Добавление сборок в менеджер." )]
		public void AddAssemblies () {
			IAssemblyBehaviourManager manager = new AssemblyBehaviourManager ();
			var assembly = CreateAssembly ();
			manager.AddAssembly ( assembly );

			Assert.IsTrue ( manager.Assemblies.Count () == 1 , "Количество сборок некорректно." );

			manager.AddAssembly ( assembly );
			Assert.IsTrue ( manager.Assemblies.Count () == 2 , "Количество сборок некорректно." );

			manager.AddAssemblies ( new List<Assembly>{
				assembly,
				assembly
			} );
			Assert.IsTrue ( manager.Assemblies.Count () == 4 , "Количество сборок некорректно." );
		}

	}
}
