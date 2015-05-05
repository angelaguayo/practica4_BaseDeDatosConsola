using System;
using MySql.Data.MySqlClient;
namespace basedatos
{
	public class Alumnos : MySQL
	{
		public Alumnos ()
		{
		}
		
		public void mostrarTodos(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          myConnection);
			Console.WriteLine("+-----------------------------------+");
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
	            string id = myReader["id"].ToString();
	            string telefono = myReader["telefono"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            Console.WriteLine("|ID: " + id +"\n"+
				                  "|telefono: " + telefono +"\n"+
				                  "|Nombre: " + nombre+"\n|");
				                  
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			Console.WriteLine("+-----------------------------------+");
			this.cerrarConexion();
		}
		
		public void insertarRegistroNuevo(string nombre, string telefono, string id){
			this.abrirConexion();
			string sql = "INSERT INTO `personas` VALUES ('" + nombre + "', '" + telefono + "','"+id+"')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		public void editarTelefonoRegistro(string id, string telefono){
			this.abrirConexion();
			string sql = "UPDATE `personas` SET `telefono`='" + telefono + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		public void editarNombreRegistro(string id, string nombre){
			this.abrirConexion();
			string sql = "UPDATE `personas` SET `nombre`='" + nombre + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		public void eliminarRegistroPorId(string id){
			this.abrirConexion();
			string sql = "DELETE FROM `personas` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}
		
		private string querySelect(){
			return "SELECT * " +
	           	"FROM personas";
		}
	}
}

