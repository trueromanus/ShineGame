using System.IO;
using System.Runtime.Serialization;
using System.Text;
using GameLevel.Implementations;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace GameLevelLibrary {

	[ContentTypeWriter]
	class LevelContentWriter : ContentTypeWriter<GameLevelData> {

		protected override void Write ( ContentWriter output , GameLevelData value ) {
			var stream = new MemoryStream ();
			var serializer = new DataContractSerializer ( typeof ( GameLevelData ) );
			serializer.WriteObject ( stream , value );
			stream.Position = 0;
			byte[] buffer = new byte[stream.Length];
			stream.Read ( buffer , 0 , buffer.Length );
			var str = Encoding.UTF8.GetString ( buffer );
			output.Write ( str );
		}

		public override string GetRuntimeType ( TargetPlatform targetPlatform ) {
			return typeof ( GameLevelData ).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader ( TargetPlatform targetPlatform ) {
			return "GameLevel.LevelContentReader, GameLevel," + " Version=1.0.0.0, Culture=neutral";
		}
	}
}
