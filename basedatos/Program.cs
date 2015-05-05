using System;

namespace basedatos
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int menu;
			string nombre;
			string telefono,id;
			Alumnos alumnos = new Alumnos();
			do{
			Console.WriteLine("co co comenzamos\n1-agregar\n2-mostrar\n3-editar  por id\n4-eliminar\n");
				menu=int.Parse(Console.ReadLine());
			switch(menu){
				case 1: 
					Console.WriteLine("nombre?");
					nombre=Console.ReadLine();
					Console.WriteLine("telefono?");
					telefono=Console.ReadLine();
					Console.WriteLine("id?");
					id=Console.ReadLine();
					alumnos.insertarRegistroNuevo(nombre,telefono,id);
					nombre="";
					telefono="";
					id="";
				break;
				
				case 2: alumnos.mostrarTodos();
		
				break;
				
				case 3: 
				Console.WriteLine("modificar? \n1-nombre\n2-telefono\n3-salir\n");
				int menu2 = int.Parse(Console.ReadLine());
				switch(menu2){
						case 1 :
							Console.WriteLine("id?");
							id=Console.ReadLine();
							Console.WriteLine("nombre a modificar?");
							nombre=Console.ReadLine();
							alumnos.editarNombreRegistro(id,nombre);
							break;
						case 2 :Console.WriteLine("id?");
							id=Console.ReadLine();
							Console.WriteLine("telefono a modificar?");
							telefono=Console.ReadLine();
							alumnos.editarTelefonoRegistro(id,telefono);
							break;
				}
							break;
				
				case 4:
					Console.WriteLine("id?");
					id=Console.ReadLine();
					alumnos.eliminarRegistroPorId(id);
					break;
			}
			}while(menu != 5);
			
		}
	}
}
