using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AbstractGameLogic.Attributes;
using LevelPropertyEditor.Models;

namespace LevelPropertyEditor.Implementation {

	/// <summary>
	/// Менеджер сборок поведений.
	/// </summary>
	public class AssemblyBehaviourManager : IAssemblyBehaviourManager {

		List<AssemblyBehaviourModel> m_Assemblies = new List<AssemblyBehaviourModel> ();

		/// <summary>
		/// Последовательность сборок поведений.
		/// </summary>
		public IEnumerable<AssemblyBehaviourModel> Assemblies {
			get {
				return m_Assemblies;
			}
		}

		/// <summary>
		/// Добавить сборку.
		/// </summary>
		/// <param name="assembly">Сборка содержащая классы поведений.</param>
		public void AddAssembly ( Assembly assembly ) {
			var assemblyData = assembly.GetCustomAttribute ( typeof ( AssemblyBehaviourAttribute ) ) as AssemblyBehaviourAttribute;
			m_Assemblies.Add (
				new AssemblyBehaviourModel {
					Name = assemblyData.Name ,
					Description = assemblyData.Description ,
					Behaviours = assembly.GetTypes ()
						.Where ( a => a.GetCustomAttributes ( false ).Any ( attribute => attribute is ObjectBindBehaviourAttribute ) )
						.Select ( a =>
							new BehaviourModel {
								Actions = a.GetCustomAttributes ( false )
									.OfType<GameActionAttribute> ()
									.Select ( action => new ActionModel {
										Name = action.Name ,
										Description = action.Description
									} )
									.ToList () ,
								Events = a.GetCustomAttributes ( false )
									.OfType<GameEventAttribute> ()
									.Select ( @event => new EventModel {
										Name = @event.Name ,
										Description = @event.Description
									} )
									.ToList () ,
								States = a.GetCustomAttributes ( false )
									.OfType<GameStateAttribute> ()
									.Select ( state => new StateModel {
										Name = state.Name ,
										Description = state.Description
									} )
									.ToList () ,
							}
						)
						.ToList ()
				}
			);
		}

		/// <summary>
		/// Добавить сборки.
		/// </summary>
		/// <param name="assembly">Последовательность сборок содержащих классы поведений.</param>
		public void AddAssemblies ( IEnumerable<Assembly> assemblies ) {
			foreach ( var assembly in assemblies ) AddAssembly ( assembly );
		}
	}
}
