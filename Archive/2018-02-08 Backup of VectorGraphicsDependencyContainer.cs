//using System;

//namespace JJ.Framework.VectorGraphics
//{
//	public static class VectorGraphicsDependencyContainer
//	{
//		private static IDrawer _drawer;

//		internal static IDrawer Drawer
//		{
//			get
//			{
//				if (_drawer == null)
//				{
//					throw new Exception(
//						$"{typeof(VectorGraphicsDependencyContainer).Assembly.GetName().Name} not initialized. " +
//						$"Please call {nameof(VectorGraphicsDependencyContainer)}.{nameof(Initialize)}.");
//				}

//				return _drawer;
//			}
//		}

//		public static void Initialize<TDrawer>()
//			where TDrawer : IDrawer, new()
//		{
//			if (_drawer == null)
//			{
//				_drawer = new TDrawer();
//			}
//		}
//	}
//}