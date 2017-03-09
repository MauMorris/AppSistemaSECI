using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;

namespace SistemaSECI
{
    class TablasDBHelper
    {
        private readonly string DATABASE_NAME = "SECI.db";

        SQLiteConnection conexionSeci;
        SQLiteCommand command;

        public TablasDBHelper()
        {
            //creamos la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //-----------------------------------------//---------------------------------------------------//
            //creacion de la tabla de datos de usuario
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_DATOS_USUARIO_TABLE;    //Crear la tabla para los datos del usuario
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de la tabla de alimentacion
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_DIETA_DIARIA_TABLE;            //Crear la tabla de alimentacion
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de la tabla de IMC
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_IMC_TABLE;              //Crear la tabla de actualizacion del IMC
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de la tabla de USUARIO IMC LLAVES
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_LLAVES_USUARIO_IMC_TABLE;//Crear la tabla de usuario IMC
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de las tablas de sesion de alimentacion
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_SESION_ALIMENTACION_TABLE;     //Crear la tabla de relacion entre alimentacion / usuario
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de las 3(TRES) tablas de kinect
            //-----------------------------------------//---------------------------------------------------//
            command.CommandText = Create.SQL_CREATE_MOVIMIENTOS_JUEGO_TABLE;       //Crear la tabla de detalles demovimientos de cada sub-nivel
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_LOGROS_SESION_JUEGO_TABLE;     //Crear la tabla de logros de sesion del juego
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_SESION_KINECT_TABLE;           //Crea la tabla de relacion entre kinect
            command.ExecuteNonQuery();                                      //execute SQL query
            //-----------------------------------------//---------------------------------------------------//
            //creacion de las 7(SIETE) tablas de SECI
            //-----------------------------------------//---------------------------------------------------//
           command.CommandText = Create.SQL_CREATE_PARAMETROS_SESION_SECI_TABLE;   //Crear la tabla para los parametros de la sesion de SECI
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_IMAGENES_CALIDAD_ALTA_BAJA_SECI_TABLE;//crea la tabla de las imagenes de seci
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_TIPO_REFORZADOR_SECI_TABLE;    //crea la tabla del reforzador (comidas) etc.
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_IMAGEN_SELECCIONADA_SECI_TABLE;//crea la tabla de las imagenes seleccionadas de seci
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_SESION_MUESTREO_SECI_TABLE;    //crea la tabla de relacion de muestreo de seci
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_PRUEBA_SECI_TABLE;             //crea la tabla de pruebas de seci
            command.ExecuteNonQuery();                                      //execute SQL query
            command.CommandText = Create.SQL_CREATE_SESION_SECI_TABLE;             //crea la tabla de relacion de sesion de seci
            command.ExecuteNonQuery();                                      //execute SQL query

            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para datos de usuario 10 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarDatosUsuario(string codigoUsuario, string nombre, string apellido, int edad,
                                    string escolaridad, string sexo, string tutor, int edadTutor, 
                                    string telefonoTutor, string mail)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();

            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_DATOS_USUARIO = "INSERT INTO " + Contrato.DatosUsuario.TABLE_NAME + "( " + 
                                        Contrato.DatosUsuario.ID + ", " +
                                        Contrato.DatosUsuario.CODIGO + ", " + 
                                        Contrato.DatosUsuario.NOMBRE + ", " +
                                        Contrato.DatosUsuario.APELLIDOS + ", " + 
                                        Contrato.DatosUsuario.EDAD + ", " +
                                        Contrato.DatosUsuario.ESCOLARIDAD + ", " + 
                                        Contrato.DatosUsuario.SEXO + ", " +
                                        Contrato.DatosUsuario.TUTOR + ", " + 
                                        Contrato.DatosUsuario.EDAD_TUTOR + ", " + 
                                        Contrato.DatosUsuario.TELEFONO_TUTOR + ", " +
                                        Contrato.DatosUsuario.MAIL + 
                                        " ) VALUES (NULL, '" + 
                                            codigoUsuario + "', '" + 
                                            nombre + "', '" + 
                                            apellido + "', " + 
                                            edad + ", '" + 
                                            escolaridad + "', '" + 
                                            sexo + "', '" + 
                                            tutor + "', " + 
                                            edadTutor + ", '" + 
                                            telefonoTutor + "', '" + 
                                            mail + "' )";
            //execute SQL query
            command.CommandText = SQL_INSERT_DATOS_USUARIO;
            command.ExecuteNonQuery();            
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para el IMC en Kinect
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarImc(double estatura, double peso, double imc)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Insert data
            string SQL_INSERT_IMC = "INSERT INTO " + Contrato.Imc.TABLE_NAME + "( " +
                                            Contrato.Imc.ID + ", " +
                                            Contrato.Imc.ESTATURA + ", " +
                                            Contrato.Imc.PESO + ", " +
                                            Contrato.Imc.IMC +
                                            " ) VALUES (NULL, " +
                                                estatura + ", " +
                                                peso + ", " +
                                                imc + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_IMC;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert llaves usuario IMC
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarLlavesUsuarioImc(int usuario, int imc)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Insert data
            string SQL_INSERT_USUARIO_IMC = "INSERT INTO " + Contrato.LlavesUsuarioImc.TABLE_NAME + "( " +
                                            Contrato.LlavesUsuarioImc.ID + ", " +
                                            Contrato.LlavesUsuarioImc.LLAVE_USUARIO + ", " +
                                            Contrato.LlavesUsuarioImc.LLAVE_IMC +
                                            " ) VALUES (NULL, " +
                                                usuario + ", " +
                                                imc + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_USUARIO_IMC;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para dieta diaria en alimentacion 8 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarDietaDiaria(string diaSemana, string desayuno, string almuerzo, string comida, string merienda,
                                        string cena, int rubrica, string comentarios)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_DIETA_DIARIA = "INSERT INTO " + Contrato.DietaDiaria.TABLE_NAME + "( " + 
                                        Contrato.DietaDiaria.ID + ", " +
                                        Contrato.DietaDiaria.DIA_SEMANA + ", " + 
                                        Contrato.DietaDiaria.DESAYUNO + ", " + 
                                        Contrato.DietaDiaria.ALMUERZO + ", " + 
                                        Contrato.DietaDiaria.COMIDA + ", " + 
                                        Contrato.DietaDiaria.MERIENDA + ", " + 
                                        Contrato.DietaDiaria.CENA + ", " + 
                                        Contrato.DietaDiaria.RUBRICA + ", " + 
                                        Contrato.DietaDiaria.COMENTARIOS + 
                                        " ) VALUES (NULL, '" + 
                                        diaSemana + "', '" + 
                                        desayuno + "', '" + 
                                        almuerzo + "', '" + 
                                        comida + "', '" + 
                                        merienda + "', '" + 
                                        cena + "', " + 
                                        rubrica + ", '" + 
                                        comentarios + "')";
            //execute SQL query
            command.CommandText = SQL_INSERT_DIETA_DIARIA;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para tabla de llaves (Sesion Alimentacion)
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarSesionAlimentacion(int sesion, int dietaDiariaId, int datosUsuarioId, int imcId)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_SESION_ALIMENTACION = "INSERT INTO " + Contrato.SesionAlimentacion.TABLE_NAME + "( " +
                                        Contrato.SesionAlimentacion.ID + ", " +
                                        Contrato.SesionAlimentacion.SESION + ", " + 
                                        Contrato.SesionAlimentacion.DIETA_DIARIA_ID + ", " +
                                        Contrato.SesionAlimentacion.DATOS_USUARIO_ID +
                                        " ) VALUES (NULL, " +
                                        sesion + ", " + 
                                        dietaDiariaId + ", " +
                                        datosUsuarioId + ", " + 
                                        imcId + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_SESION_ALIMENTACION;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para logros de la sesion de juego en kinect
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarLogrosSesionJuego(string tiempoJuego, int monedasRecolectadas, int nivel, 
                                        int movimientosJuegoId)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //table Update
            string SQL_INSERT_LOGROS_SESION_JUEGO = "INSERT INTO " + Contrato.LogrosSesionJuego.TABLE_NAME + "( " +
                                        Contrato.LogrosSesionJuego.ID + ", " +
                                        Contrato.LogrosSesionJuego.TIEMPO_JUEGO + ", " +
                                        Contrato.LogrosSesionJuego.MONEDAS_RECOLECTADAS + ", " + 
                                        Contrato.LogrosSesionJuego.NIVEL + ", " +
                                        Contrato.LogrosSesionJuego.MOVIMIENTOS_JUEGO_ID + 
                                        " ) VALUES (NULL, " +
                                        tiempoJuego + ", " +
                                        monedasRecolectadas + ", " + 
                                        nivel + ", " +
                                        movimientosJuegoId + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_LOGROS_SESION_JUEGO;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para la descripcion de los movimientos del juego en Kinect
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarMovimientosJuego(string movimiento, string descripcion, string dificultad)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //table Update
            string SQL_INSERT_MOVIMIENTOS_JUEGO = "INSERT INTO " + Contrato.MovimientosJuego.TABLE_NAME + "( " +
                                        Contrato.MovimientosJuego.ID + ", " +
                                        Contrato.MovimientosJuego.MOVIMIENTO + ", " +
                                        Contrato.MovimientosJuego.DESCRIPCION + ", " +
                                        Contrato.MovimientosJuego.DIFICULTAD +
                                        " ) VALUES (NULL, '" +
                                        movimiento + "', '" + descripcion + "', '" +
                                        dificultad + "')";
            //execute SQL query
            command.CommandText = SQL_INSERT_MOVIMIENTOS_JUEGO;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert para la tabla de llaves de kinect (Sesion Kinect)
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarSesionKinect(int sesion, int logrosSesionJuegoId, int datosUsuarioId)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Insert data
            string SQL_INSERT_SESION_KINECT = "INSERT INTO " + Contrato.SesionKinect.TABLE_NAME + "( " +
                                            Contrato.SesionKinect.ID + ", " +
                                            Contrato.SesionKinect.SESION + ", " + 
                                            Contrato.SesionKinect.LOGROS_SESION_JUEGO_ID + ", " +
                                            Contrato.SesionKinect.DATOS_USUARIO_ID +
                                            " ) VALUES (NULL, " +
                                                sesion + ", '" + logrosSesionJuegoId + "', " + 
                                                datosUsuarioId + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_SESION_KINECT;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert parametros de sesion en SECI
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarParametrosSesion(string reforzadorTipo, string reforzadorClase, int numeroSeries,
                                    string inmeInmediato, string inmeDemorado, int esfuerzoAlto, int esfuerzoBajo,
                                    int programaReforzamientoAlto, int programaReforzamientoBajo, string tipoSesion)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();

            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_PARAMETROS_SESION = "INSERT INTO " + Contrato.ParametrosSeci.TABLE_NAME + "( " +
                                        Contrato.ParametrosSeci.ID + ", " +
                                        Contrato.ParametrosSeci.REFORZADOR_TIPO + ", " + 
                                        Contrato.ParametrosSeci.REFORZADOR_CLASE + ", " +
                                        Contrato.ParametrosSeci.INMEDIATEZ_INMEDIATO + ", " + 
                                        Contrato.ParametrosSeci.INMEDIATEZ_DEMORADO + ", " +
                                        Contrato.ParametrosSeci.ESFUERZO_ALTO + ", " + 
                                        Contrato.ParametrosSeci.ESFUERZO_BAJO + ", " +
                                        Contrato.ParametrosSeci.PROGRAMA_REF_ALTO + ", " + 
                                        Contrato.ParametrosSeci.PROGRAMA_REF_BAJO + ", " +
                                        Contrato.ParametrosSeci.NUMERO_SERIES + ", " +
                                        Contrato.ParametrosSeci.TIPO_SESION +
                                        " ) VALUES (NULL, '" + 
                                            reforzadorTipo + "', '" + 
                                            reforzadorClase + "', '" + 
                                            inmeInmediato + "', '" + 
                                            inmeDemorado + "', " + 
                                            esfuerzoAlto + ", " + 
                                            esfuerzoBajo + ", " +
                                            programaReforzamientoAlto + ", " + 
                                            programaReforzamientoBajo + ", " +
                                            numeroSeries + ", '" +
                                            tipoSesion + "')";
            //execute SQL query
            command.CommandText = SQL_INSERT_PARAMETROS_SESION;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert imagenes de calidad alta y baja para la base de datos de kinect
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarCalidadAltaBaja(string nombre, string uri,
                                    string calidad, string tipoReforzador)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();

            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_IMAGENES_CALIDAD_ALTA_BAJA = "INSERT INTO " + Contrato.ImagenesCalidadAltaBajaSeci.TABLE_NAME + "( " +
                                        Contrato.ImagenesCalidadAltaBajaSeci.ID + ", " +
                                        Contrato.ImagenesCalidadAltaBajaSeci.NOMBRE + ", " + 
                                        Contrato.ImagenesCalidadAltaBajaSeci.URI + ", " +
                                        Contrato.ImagenesCalidadAltaBajaSeci.CALIDAD + ", " + 
                                        Contrato.ImagenesCalidadAltaBajaSeci.TIPO_REFORZADOR_ID +
                                        " ) VALUES (NULL, '" +
                                            nombre + "', '" + 
                                            uri + "', '" +
                                            calidad + "', '" + 
                                            tipoReforzador + "')";
            //execute SQL query
            command.CommandText = SQL_INSERT_IMAGENES_CALIDAD_ALTA_BAJA;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert de tipo de reforzador describiendo el tipo de imagenes en el muestreo de SECI
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarTipoReforzadorSeci(string reforzador, string descripcion)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();

            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_TIPO_REFORZADOR_SECI = "INSERT INTO " + Contrato.TipoReforzadorSeci.TABLE_NAME + "( " +
                                        Contrato.TipoReforzadorSeci.ID + ", " +
                                        Contrato.TipoReforzadorSeci.REFORZADOR + ", " + 
                                        Contrato.TipoReforzadorSeci.DESCRIPCION +
                                        " ) VALUES (NULL, '" +
                                            reforzador + "', '" + 
                                            descripcion + "')";
            //execute SQL query
            command.CommandText = SQL_INSERT_TIPO_REFORZADOR_SECI;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert de la imagen seleccionada en el muestreo de SECI
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarImagenSeleccionada(int imagenSeleccionadaId, int numeroElecciones)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Insert data
            string SQL_INSERT_IMAGEN_SELECCIONADA = "INSERT INTO " + Contrato.ImagenSeleccionadaSeci.TABLE_NAME + "( " +
                                            Contrato.ImagenSeleccionadaSeci.ID + ", " +
                                            Contrato.ImagenSeleccionadaSeci.IMAGEN_SELECCIONADA_ID + ", " + 
                                            Contrato.ImagenSeleccionadaSeci.NUMERO_ELECCIONES +
                                            " ) VALUES (NULL, " +
                                                imagenSeleccionadaId + ", " + 
                                                numeroElecciones + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_IMAGEN_SELECCIONADA;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
        //-----------------------------------------//---------------------------------------------------//
        //insert de ls 45 elecciones en la sesion de muestreo de SECI
        //-----------------------------------------//---------------------------------------------------//
        public void InsertarSesionMuestreo(string i1, string i2, string resultado, string tiempo, 
                                            int sesion, int parametrosSesionId, int datosUsuarioId)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();

            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_INSERT_SESION_MUESTREO = "INSERT INTO " + Contrato.SesionMuestreoSeci.TABLE_NAME + "( " +
                                        Contrato.SesionMuestreoSeci.ID + ", " +
                                        Contrato.SesionMuestreoSeci.IMAGEN_1 + ", " + 
                                        Contrato.SesionMuestreoSeci.IMAGEN_2 + ", " +
                                        Contrato.SesionMuestreoSeci.RESULTADO_ID + ", " + 
                                        Contrato.SesionMuestreoSeci.TIEMPO_ELECCION + ", " +
                                        Contrato.SesionMuestreoSeci.SESION + ", " + 
                                        Contrato.SesionMuestreoSeci.PARAMETROS_SECI_ID + ", " +
                                        Contrato.SesionMuestreoSeci.DATOS_USUARIO_ID +
                                        " ) VALUES (NULL, '" +
                                            i1 + "', '" + 
                                            i2 + "', '" +
                                            resultado + "', '" + 
                                            tiempo + "', " +
                                            sesion + ", " + 
                                            parametrosSesionId + ", " +
                                            datosUsuarioId + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_SESION_MUESTREO;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
/*
        public void InsertarResultadosSerie(int pruebas, int calidad_alta, int calidad_baja, int inmediatez_inmediato,
                                            int inmediatez_demorado, int esfuerzo_alto, int esfuerzo_bajo, int prog_ref_alto,
                                            int prog_ref_bajo, int muestreo_calidad_id, int parametros_sesion_id, int datos_usuario_id)
        {

        //crear la conexion a la base de datos
        conexionSeci = new SQLiteConnection("Data Source = " + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Insert data
            string SQL_INSERT_RESULTADOS_SERIE_SECI = "INSERT INTO " + ContratoSeci.ResultadosSerieSeci.TABLE_NAME + "( " +
                                            ContratoSeci.ResultadosSerieSeci.ID + ", " +
                                            ContratoSeci.ResultadosSerieSeci.PRUEBAS + ", " + 
                                            ContratoSeci.ResultadosSerieSeci.CALIDAD_ALTA + ", " +
                                            ContratoSeci.ResultadosSerieSeci.CALIDAD_BAJA + ", " +
                                            ContratoSeci.ResultadosSerieSeci.INMEDIATEZ_INMEDIATO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.INMEDIATEZ_DEMORADO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.ESFUERZO_ALTO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.ESFUERZO_BAJO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.PROGRAMA_REFORZAMIENTO_ALTO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.PROGRAMA_REFORZAMIENTO_BAJO + ", " +
                                            ContratoSeci.ResultadosSerieSeci.MUESTREO_CALIDAD_SECI_ID + ", " +
                                            ContratoSeci.ResultadosSerieSeci.PARAMETROS_SESION_SECI_ID + ", " +
                                            ContratoSeci.ResultadosSerieSeci.DATOS_USUARIO_ID +
                                            " ) VALUES (NULL, " +
                                                pruebas + ", " + calidad_alta + ", " +
                                                calidad_baja +", " + inmediatez_inmediato +", " +
                                                inmediatez_demorado +", " + esfuerzo_alto +", " +
                                                esfuerzo_bajo +", " + prog_ref_alto +", " +
                                                prog_ref_bajo +", " + muestreo_calidad_id +", " +
                                                parametros_sesion_id +", " + datos_usuario_id + ")";
            //execute SQL query
            command.CommandText = SQL_INSERT_RESULTADOS_SERIE_SECI;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
*/
/// /////////////////////////////METODOS UPDATE
/// 
        public void UpdateDatosUsuario(int id, string codigoUsuario, string nombre, string apellidos, int edad,
                                    string escolaridad, string sexo, string tutor, int edadTutor, 
                                    string telefonoTutor, string mail)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_UPDATE_DATOS_USUARIO = "UPDATE " + 
                                                    Contrato.DatosUsuario.TABLE_NAME +
                                              " SET " + 
                                                    Contrato.DatosUsuario.CODIGO + " = '" + codigoUsuario + "', " +
                                                    Contrato.DatosUsuario.NOMBRE + " = '" + nombre + "', " +
                                                    Contrato.DatosUsuario.APELLIDOS + " = '" + apellidos + "', " +
                                                    Contrato.DatosUsuario.EDAD + " = " + edad + ", " +
                                                    Contrato.DatosUsuario.ESCOLARIDAD + " = '" + escolaridad + "', " +
                                                    Contrato.DatosUsuario.SEXO + " = '" + sexo + "', " +
                                                    Contrato.DatosUsuario.TUTOR + " = '" + tutor + "', " +
                                                    Contrato.DatosUsuario.EDAD_TUTOR + " = " + edadTutor + ", " +
                                                    Contrato.DatosUsuario.TELEFONO_TUTOR + " = '" + telefonoTutor + "', " +
                                                    Contrato.DatosUsuario.MAIL + " = '" + mail + "' " +
                                                    " WHERE " +
                                                    Contrato.DatosUsuario.ID + " = " + id;
            //execute SQL query
            command.CommandText = SQL_UPDATE_DATOS_USUARIO;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
/// <summary>
/// UPDATE IMC
/// 
        public void UpdateImc(int id, double estatura, double peso, double imc)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Inserting data
            string SQL_UPDATE_IMC = "UPDATE " + 
                                            Contrato.Imc.TABLE_NAME +
                                    " SET " + 
                                            Contrato.Imc.ESTATURA + " = " + estatura + ", " +
                                            Contrato.Imc.PESO + " = " + peso + ", " +
                                            Contrato.Imc.IMC + " = " + imc + 
                                    " WHERE " + 
                                            Contrato.Imc.ID + " = " + id;
            //execute SQL query
            command.CommandText = SQL_UPDATE_IMC;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }
////////////METODOS READ
/// 
        public Seci RegresaParametrosSesion(int id)
        {
            Seci parametrosConsulta = new Seci();

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_PARAMETROS_SECI = "SELECT * FROM " + Contrato.ParametrosSeci.TABLE_NAME +
                                                    " WHERE " + Contrato.ParametrosSeci.ID + " = " + id + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_PARAMETROS_SECI;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                parametrosConsulta.Sesion = Convert.ToString(reader[Contrato.ParametrosSeci.TIPO_SESION]);
                parametrosConsulta.ReforzadorTipo = Convert.ToString(reader[Contrato.ParametrosSeci.REFORZADOR_TIPO]);
                parametrosConsulta.ReforzadorClase = Convert.ToString(reader[Contrato.ParametrosSeci.REFORZADOR_CLASE]);
                parametrosConsulta.InmediatezI = Convert.ToString(reader[Contrato.ParametrosSeci.INMEDIATEZ_INMEDIATO]);
                parametrosConsulta.InmediatezD = Convert.ToString(reader[Contrato.ParametrosSeci.INMEDIATEZ_DEMORADO]);
                parametrosConsulta.EsfuerzoAlto = Convert.ToInt32(reader[Contrato.ParametrosSeci.ESFUERZO_ALTO]);
                parametrosConsulta.EsfuerzoBajo = Convert.ToInt32(reader[Contrato.ParametrosSeci.ESFUERZO_BAJO]);
                parametrosConsulta.ReforzamientoAlto = Convert.ToInt32(reader[Contrato.ParametrosSeci.PROGRAMA_REF_ALTO]);
                parametrosConsulta.ReforzamientoBajo = Convert.ToInt32(reader[Contrato.ParametrosSeci.PROGRAMA_REF_BAJO]);
            }
            conexionSeci.Close();

            return parametrosConsulta;
        }

        public int ConsultaIdUltimoUsuario()
        {
            int idUltimo = 0;
            int idUsuario = 0;

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_ULTIMO_USUARIO = "SELECT * FROM " + Contrato.DatosUsuario.TABLE_NAME +
                                                    " WHERE " + Contrato.DatosUsuario.ID + " = (SELECT MAX( " +
                                                    Contrato.DatosUsuario.ID + ") FROM " +
                                                    Contrato.DatosUsuario.TABLE_NAME + "); ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_ULTIMO_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Int32.TryParse(Convert.ToString(reader[0]), out idUltimo))
                    idUsuario = idUltimo;
                else
                    idUsuario = 1;
            }

            conexionSeci.Close();
            return idUsuario;
        }

        public int ConsultaIdUltimoImc()
        {
            int idUltimo = 0;
            int idUsuario = 0;

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_ULTIMO_USUARIO = "SELECT * FROM " + Contrato.Imc.TABLE_NAME +
                                                    " WHERE " + Contrato.Imc.ID + " = (SELECT MAX( " +
                                                    Contrato.Imc.ID + ") FROM " +
                                                    Contrato.Imc.TABLE_NAME + "); ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_ULTIMO_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Int32.TryParse(Convert.ToString(reader[0]), out idUltimo))
                    idUsuario = idUltimo;
                else
                    idUsuario = 1;
            }

            conexionSeci.Close();
            return idUsuario;
        }

        public int ConsultaUltimoLlaves()
        {
            int idUltimo = 0;
            int idUsuario = 0;

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_ULTIMO_USUARIO = "SELECT * FROM " + Contrato.LlavesUsuarioImc.TABLE_NAME +
                                                    " WHERE " + Contrato.LlavesUsuarioImc.ID + " = (SELECT MAX( " +
                                                    Contrato.LlavesUsuarioImc.ID + ") FROM " +
                                                    Contrato.LlavesUsuarioImc.TABLE_NAME + "); ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_ULTIMO_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Int32.TryParse(Convert.ToString(reader[0]), out idUltimo))
                    idUsuario = idUltimo;
                else
                    idUsuario = 1;
            }

            conexionSeci.Close();
            return idUsuario;
        }
/// <summary>
/// Regresa el Id del ultimo ingreso en la tabla de de parametros de seci
/// </summary>
        public int ConsultaIdUltimoParametrosSeci()
        {
            int idUltimo = 0;
            int idParametro = 0;

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_ULTIMO_PARAMETRO_SECI = "SELECT * FROM " + Contrato.ParametrosSeci.TABLE_NAME +
                                                    " WHERE " + Contrato.ParametrosSeci.ID + " = (SELECT MAX( " +
                                                    Contrato.ParametrosSeci.ID + ") FROM " +
                                                    Contrato.ParametrosSeci.TABLE_NAME + "); ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_ULTIMO_PARAMETRO_SECI;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Int32.TryParse(Convert.ToString(reader[0]), out idUltimo))
                    idParametro = idUltimo;
                else
                    idParametro = 1;
            }
            conexionSeci.Close();
            return idParametro;
        }
/// <summary>
/// Regresa un string que concatena los datos relevantes para describir a un usuario reciente consultado ID
        public string RegresaUsuarioConsulta(int id)
        {
            string usuarioConcatenadoConsulta = string.Empty;

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_USUARIO = "SELECT * FROM " + Contrato.DatosUsuario.TABLE_NAME +
                                                    " WHERE " + Contrato.DatosUsuario.ID + " = " + id + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                usuarioConcatenadoConsulta += Convert.ToString(reader[Contrato.DatosUsuario.CODIGO]) + " ";
                usuarioConcatenadoConsulta += Convert.ToString(reader[Contrato.DatosUsuario.NOMBRE]) + " ";
                usuarioConcatenadoConsulta += Convert.ToString(reader[Contrato.DatosUsuario.APELLIDOS]) + " ";
                usuarioConcatenadoConsulta += Convert.ToString(reader[Contrato.DatosUsuario.EDAD]) + " ";
                usuarioConcatenadoConsulta += Convert.ToString(reader[Contrato.DatosUsuario.ESCOLARIDAD]);
            }
            conexionSeci.Close();

            return usuarioConcatenadoConsulta;
        }
/// <summary>
/// Regresa todos los datos del usuario consultado
        public DatosUsuario RegresaDatosUsuarioConsulta(int id)
        {
            DatosUsuario usuarioConcatenadoConsulta = new DatosUsuario();

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_USUARIO = "SELECT * FROM " + Contrato.DatosUsuario.TABLE_NAME +
                                                    " WHERE " + Contrato.DatosUsuario.ID + " = " + id + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                usuarioConcatenadoConsulta.Codigo = Convert.ToString(reader[Contrato.DatosUsuario.CODIGO]);
                usuarioConcatenadoConsulta.Nombre = Convert.ToString(reader[Contrato.DatosUsuario.NOMBRE]);
                usuarioConcatenadoConsulta.Apellidos = Convert.ToString(reader[Contrato.DatosUsuario.APELLIDOS]);
                usuarioConcatenadoConsulta.Edad = Convert.ToInt32(reader[Contrato.DatosUsuario.EDAD]);
                usuarioConcatenadoConsulta.Escolaridad = Convert.ToString(reader[Contrato.DatosUsuario.ESCOLARIDAD]);
                usuarioConcatenadoConsulta.Sexo = Convert.ToString(reader[Contrato.DatosUsuario.SEXO]);
                usuarioConcatenadoConsulta.NombreTutor = Convert.ToString(reader[Contrato.DatosUsuario.TUTOR]);
                usuarioConcatenadoConsulta.EdadTutor = Convert.ToInt32(reader[Contrato.DatosUsuario.EDAD_TUTOR]);
                usuarioConcatenadoConsulta.TelefonoTutor = Convert.ToString(reader[Contrato.DatosUsuario.TELEFONO_TUTOR]);
                usuarioConcatenadoConsulta.Mail = Convert.ToString(reader[Contrato.DatosUsuario.MAIL]);
            }
            conexionSeci.Close();

            return usuarioConcatenadoConsulta;
        }
/// <summary>
/// Regresa los datos almacenados en la tabla IMC consultados con el ID con la forma de objeto Imc
        public Imc RegresaImcUsuarioConsulta(int id)
        {
            Imc ImcConcatenadoConsulta = new Imc();

            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_CONSULT_USUARIO = "SELECT * FROM " + Contrato.Imc.TABLE_NAME +
                                                    " WHERE " + Contrato.Imc.ID + " = " + id + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ImcConcatenadoConsulta.Peso = Convert.ToDouble(reader[Contrato.Imc.PESO]);
                ImcConcatenadoConsulta.Estatura = Convert.ToDouble(reader[Contrato.Imc.ESTATURA]);
                ImcConcatenadoConsulta.IMC = Convert.ToDouble(reader[Contrato.Imc.IMC]);
            }
            conexionSeci.Close();

            return ImcConcatenadoConsulta;
        }
/// <summary>
/// Regresa todos los ID de la tabla de datos de usuario
        public ArrayList RegresaTodosId()
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();

            ArrayList idArreglo = new ArrayList();

            string SQL_CONSULT_USUARIO = "SELECT " + Contrato.DatosUsuario.ID + " FROM " +
                                            Contrato.DatosUsuario.TABLE_NAME + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                idArreglo.Add(Convert.ToInt32(reader[0]));
            }
            conexionSeci.Close();

            return idArreglo;
        }
/// <summary>
/// Regresa las llavesconsultadas en la tabla de llaves IMC y Datos de Usuario
        public int[] RegresaLlavesUsuarioImc(int id)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            int[] llaves = { 0, 0 };
            string SQL_CONSULT_LLAVES_USUARIO_IMC = "SELECT * FROM " + Contrato.LlavesUsuarioImc.TABLE_NAME +
                                                    " WHERE " + Contrato.LlavesUsuarioImc.ID + " = " + id + " ; ";
            //execute SQL query
            command.CommandText = SQL_CONSULT_LLAVES_USUARIO_IMC;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                llaves[0] = Convert.ToInt32(reader[Contrato.LlavesUsuarioImc.LLAVE_USUARIO]);
                llaves[1] = Convert.ToInt32(reader[Contrato.LlavesUsuarioImc.LLAVE_IMC]);
            }
            conexionSeci.Close();

            return llaves;
        }

/// <summary>
/// //////METODOS DELETE
/// 
        public void BorraDatosUsuario(int id)
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_DELETE_DATOS_USUARIO =  "DELETE FROM " + 
                                                    Contrato.DatosUsuario.TABLE_NAME +
                                                " WHERE " +
                                                    Contrato.DatosUsuario.ID + " = " + id;
            //execute SQL query
            command.CommandText = SQL_DELETE_DATOS_USUARIO;
            command.ExecuteNonQuery();
            conexionSeci.Close();
        }

        public void BorrarTodo()
        {
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_DELETE_DATOS_USUARIO = "DROP TABLE IF EXISTS " +
                                                    Contrato.DatosUsuario.TABLE_NAME;
            string SQL_DELETE_IMC = "DROP TABLE IF EXISTS " +
                                                    Contrato.Imc.TABLE_NAME;
            string SQL_DELETE_DIETA_DIARIA = "DROP TABLE IF EXISTS " +
                                                    Contrato.DietaDiaria.TABLE_NAME;
            string SQL_DELETE_SESION_ALIMENTACION = "DROP TABLE IF EXISTS " +
                                                    Contrato.SesionAlimentacion.TABLE_NAME;
            string SQL_DELETE_LOGROS_SESION_JUEGO = "DROP TABLE IF EXISTS " +
                                                    Contrato.LogrosSesionJuego.TABLE_NAME;
            string SQL_DELETE_MOVIMIENTOS_JUEGO = "DROP TABLE IF EXISTS " +
                                                    Contrato.MovimientosJuego.TABLE_NAME;
            string SQL_DELETE_SESION_KINECT = "DROP TABLE IF EXISTS " +
                                                    Contrato.SesionKinect.TABLE_NAME;
            string SQL_DELETE_PARAMETROS_SECI = "DROP TABLE IF EXISTS " +
                                                    Contrato.ParametrosSeci.TABLE_NAME;
            string SQL_DELETE_IMAGENES_CALIDAD = "DROP TABLE IF EXISTS " +
                                                    Contrato.ImagenesCalidadAltaBajaSeci.TABLE_NAME;
            string SQL_DELETE_TIPO_REFORZADOR = "DROP TABLE IF EXISTS " +
                                                    Contrato.TipoReforzadorSeci.TABLE_NAME;
            string SQL_DELETE_IMAGEN_SELECCIONADA = "DROP TABLE IF EXISTS " +
                                                    Contrato.ImagenSeleccionadaSeci.TABLE_NAME;
            string SQL_DELETE_SESION_MUESTREO = "DROP TABLE IF EXISTS " +
                                                    Contrato.SesionMuestreoSeci.TABLE_NAME;
            string SQL_DELETE_PRUEBA_SECI = "DROP TABLE IF EXISTS " +
                                                    Contrato.PruebaSeci.TABLE_NAME;
            string SQL_DELETE_SESION_SECI = "DROP TABLE IF EXISTS " +
                                                    Contrato.SesionSeci.TABLE_NAME;
            //execute SQL query
            command.CommandText = SQL_DELETE_DATOS_USUARIO;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_IMC;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_DIETA_DIARIA;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_SESION_ALIMENTACION;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_LOGROS_SESION_JUEGO;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_MOVIMIENTOS_JUEGO;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_SESION_KINECT;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_PARAMETROS_SECI;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_IMAGENES_CALIDAD;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_TIPO_REFORZADOR;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_IMAGEN_SELECCIONADA;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_SESION_MUESTREO;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_PRUEBA_SECI;
            command.ExecuteNonQuery();
            //execute SQL query
            command.CommandText = SQL_DELETE_SESION_SECI;
            command.ExecuteNonQuery();

            conexionSeci.Close();
        }

        public int ContarUsuarios()
        {
            int contador = 0;
            int contadorApoyo = 0;
            //crear la conexion a la base de datos
            conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME);
            conexionSeci.Open();
            command = conexionSeci.CreateCommand();
            //Delete Record
            string SQL_COUNT_DATOS_USUARIO = "SELECT COUNT( * ) FROM " + 
                                                Contrato.DatosUsuario.TABLE_NAME + " ; ";
            //execute SQL query
            command.CommandText = SQL_COUNT_DATOS_USUARIO;

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (Int32.TryParse(Convert.ToString(reader[0]), out contadorApoyo))
                    contador = contadorApoyo;
                else
                    contador = 0;
            }

            conexionSeci.Close();
            return contador;
        }

    }
}
