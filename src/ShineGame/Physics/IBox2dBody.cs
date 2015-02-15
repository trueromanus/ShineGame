using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2D.XNA;

namespace ShineGame.Physics {
	
	/// <summary>
	/// Тело из фреймворка Box2d.
	/// </summary>
	public interface IBox2dBody {

		/// <summary>
		/// Физическое тело.
		/// </summary>
		Body Body {
			get;
			set;
		}

	}

}
