using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SistemaSECI
{
    class ManejadorTablas
    {
        private readonly string DATABASE_NAME = "SECI";


        private readonly string TABLA_DATOS_USUARIO = "DATOS_USUARIO";

        private readonly string T_DU_ID = "ID_USUARIO";
        private readonly string T_DU_CODIGO_USUARIO = "CODIIGO_USUARIO";
        private readonly string T_DU_NOMBRE = "NOMBRE";
        private readonly string T_DU_APELLIDO = "APELLIDO";
        private readonly string T_DU_EDAD = "EDAD";
        private readonly string T_DU_ESCOLARIDAD = "ESCOLARIDAD";
        private readonly string T_DU_SEXO = "SEXO";
        private readonly string T_DU_ESTATURA = "ESTATURA";
        private readonly string T_DU_PESO = "PESO";
        private readonly string T_DU_IMC = "IMC";
        private readonly string T_DU_TUTOR = "TUTOR";
        private readonly string T_DU_EDAD_TUTOR = "EDAD_TUTOR";
        private readonly string T_DU_TELEFONO_TUTOR = "TELEFONO_TUTOR";


        private readonly string TABLA_PARAMETROS_SESION_SECI = "PARAMETROS_SESION_SECI";

        private readonly string T_PSS_ID = "ID_SESION";
        private readonly string T_PSS_NUMERO_SESION = "NUMERO_SESION";
        private readonly string T_PSS_REFORZADOR_TIPO = "REFORZADOR_TIPO";
        private readonly string T_PSS_REFORZADOR_CLASE = "REFORZADOR_CLASE";
        private readonly string T_PSS_I_INMEDIATO = "INME_INMEDIATO";
        private readonly string T_PSS_I_DEMORADO = "INME_DEMORADO";
        private readonly string T_PSS_ESFUERZO_ALTO = "ESFUERZO_ALTO";
        private readonly string T_PSS_ESFUERZO_BAJO = "ESFUERZO_BAJO";
        private readonly string T_PSS_P_REF_ALTO = "PROGRAMA_REF_ALTO";
        private readonly string T_PSS_P_REF_BAJO = "PROGRAMA_REF_BAJO";
        private readonly string T_PSS_DU_ID = "DATOS_USUARIO_ID_USUARIO";
        private readonly string T_PSS_RSS_ID = "RESULTADO_SESION_SECI_ID_RESULTADOS";

        private readonly string TABLA_RESULTADOS_SESION_SECI = "RESULTADOS_SESION_SECI";

        private readonly string T_RSS_ID = "ID_RESULTADOS";
        private readonly string T_RSS_TOTAL_PRUEBAS = "TOTAL_PRUEBAS";
        private readonly string T_RSS_I_INMEDIATO = "TOTAL_INMEDIATEZ_INMEDIATO";
        private readonly string T_RSS_I_DEMORADO = "TOTAL_INMEDIATEZ_DEMORADO";
        private readonly string T_RSS_ESFUERZO_ALTO = "TOTAL_ESFUERZO_ALTO";
        private readonly string T_RSS_ESFUERZO_BAJO = "TOTAL_ESFUERZO_BAJO";
        private readonly string T_RSS_P_REF_ALTO = "TOTAL_PROGRAMA_REFORZAMIENTO_ALTO";
        private readonly string T_RSS_P_REF_BAJO = "TOTAL_PROGRAMA_REFORZAMIENTO_BAJO";
        private readonly string T_RSS_PIS_ID = "PRUEBA_IMAGENES_SECI_ID_IMAGENES";

        private readonly string TABLA_PRUEBA_IMAGENES_SECI = "PRUEBA_IMAGENES_SECI";

        private readonly string T_PIS_ID = "ID_IMAGENES";
        private readonly string T_PIS_CALIDAD_ALTA = "CALIDAD_ALTA";
        private readonly string T_PIS_CALIDAD_BAJA = "CALIDAD_BAJA";

        private readonly string TABLA_PRUEBA_COMPLETA_SECI = "PRUEBA_COMPLETA_SECI";

        private readonly string T_PCS_ID = "ID_PRUEBA";
        private readonly string T_PCS_NUMERO_PRUEBA = "NUMERO_PRUEBA";
        private readonly string T_PCS_R_I_INMEDIATO = "RESULTADO_INMEDIATEZ_INMEDIATO";
        private readonly string T_PCS_R_I_DEMORADO = "RESULTADO_INMEDIATEZ_DEMORADO";
        private readonly string T_PCS_ESFUERZO_ALTO = "RESULTADO_ESFUERZO_ALTO";
        private readonly string T_PCS_ESFUERZO_BAJO = "RESULTADO_ESFUERZO_BAJO";
        private readonly string T_PCS_P_REF_ALTO = "RESULTADO_PROGRAMA_REFORZAMIENTO_ALTO";
        private readonly string T_PCS_P_REF_BAJO = "RESULTADO_PROGRAMA_REFORZAMIENTO_BAJO";
        private readonly string T_PCS_PSS_ID = "PARAMETROS_SESION_SECI_ID_SESION";


        private readonly string TABLA_ALIMENTACION = "ALIMENTACION";

        private readonly string T_A_ID = "ID_ALIMENTACION";
        private readonly string T_A_NUMERO_SESION = "NUMERO_SESION";
        private readonly string T_A_DIA_SEMANA = "DIA_SEMANA";
        private readonly string T_A_DESAYUNO = "DESAYUNO";
        private readonly string T_A_ALMUERZO = "ALMUERZO";
        private readonly string T_A_COMIDA = "COMIDA";
        private readonly string T_A_MERIENDA = "MERIENDA";
        private readonly string T_A_CENA = "CENA";
        private readonly string T_A_RUBRICA = "RUBRICA";
        private readonly string T_A_DU_ID = "DATOS_USUARIO_ID_USUARIO";


        private readonly string TABLA_LOGROS_SESION_JUEGO = "LOGROS_SESION_JUEGO";

        private readonly string T_LSJ_ID = "ID_LOGROS_SESION";
        private readonly string T_LSJ_NUMERO_SESION = "NUMERO_SESION";
        private readonly string T_LSJ_TIEMPO_JUEGO = "TIEMPO_JUEGO";
        private readonly string T_LSJ_MONEDAS_RECOLECTADAS = "MONEDAS_RECOLECTADAS";
        private readonly string T_LSJ_NJ_ID = "NIVELES_JUEGO_ID_NIVELES";
        private readonly string T_LSJ_MJ_ID = "MOVIMIENTOS_JUEGO_ID_MOVIMIENTOS";
        private readonly string T_LSJ_AI_ID = "ACTUAL_IMC_ID_IMC";
        private readonly string T_LSJ_LTJ_ID = "LOGROS_TOTAL_JUEGO_ID_LOGROS_TOTAL";
        private readonly string T_LSJ_DU_ID = "DATOS_USUARIO_ID_USUARIO";

        private readonly string TABLA_ACTUAL_IMC = "ACTUAL_IMC";

        private readonly string T_AI_ID = "ID_IMC";
        private readonly string T_AI_ESTATURA = "ESTATURA_IMC";
        private readonly string T_AI_PESO = "PESO_IMC";
        private readonly string T_AI_IMC_ACTUAL = "IMC_ACTUAL";

        private readonly string TABLA_LOGROS_TOTAL_JUEGO = "LOGROS_TOTAL_JUEGO";

        private readonly string T_LTJ_ID = "ID_LOGROS_TOTAL";
        private readonly string T_LTJ_TOTAL_SESIONES = "TOTAL_SESIONES";
        private readonly string T_LTJ_TOTAL_TIEMPO_JUEGO = "TOTAL_TIEMPO_JUEGO";
        private readonly string T_LTJ_TOTAL_MONEDAS_RECOLECTADAS = "TOTAL_MONEDAS_RECOLECTADAS";
        private readonly string T_LTJ_TOTAL_NIVELES = "TOTAL_NIVELES";

        private readonly string TABLA_NIVELES_JUEGO = "NIVELES_JUEGO";

        private readonly string T_NJ_ID = "ID_NIVELES";
        private readonly string T_NJ_NIVEL = "NIVEL";
        private readonly string T_NJ_SUB_1 = "SUB_NIVEL_1";
        private readonly string T_NJ_SUB_2 = "SUB_NIVEL_2";
        private readonly string T_NJ_SUB_3 = "SUB_NIVEL_3";
        private readonly string T_NJ_SUB_4 = "SUB_NIVEL_4";
        private readonly string T_NJ_SUB_5 = "SUB_NIVEL_5";
        private readonly string T_NJ_SUB_6 = "SUB_NIVEL_6";
        private readonly string T_NJ_SUB_7 = "SUB_NIVEL_7";
        private readonly string T_NJ_SUB_8 = "SUB_NIVEL_8";

        private readonly string TABLA_MOVIMIENTOS_JUEGO = "MOVIMIENTOS_JUEGO";

        private readonly string T_MJ_ID = "ID_MOVIMIENTOS";
        private readonly string T_MJ_SUB_NIVEL = "SUB_NIVEL";
        private readonly string T_MJ_CABEZA = "CABEZA";
        private readonly string T_MJ_CUELLO = "CUELLO";
        private readonly string T_MJ_HOMBRO_C = "HOMBRO_C";
        private readonly string T_MJ_HOMBRO_I = "HOMBRO_I";
        private readonly string T_MJ_CODO_I = "CODO_I";
        private readonly string T_MJ_MUÑECA_I = "MUÑECA_I";
        private readonly string T_MJ_MANO_I = "MANO_I";
        private readonly string T_MJ_DEDOS_I = "DEDOS_I";
        private readonly string T_MJ_PULGAR_I = "PULGAR_I";
        private readonly string T_MJ_HOMBRO_D = "HOMBRO_D";
        private readonly string T_MJ_CODO_D = "CODO_D";
        private readonly string T_MJ_MUÑECA_D = "MUÑECA_D";
        private readonly string T_MJ_MANO_D = "MANO_D";
        private readonly string T_MJ_DEDOS_D = "DEDOS_D";
        private readonly string T_MJ_PULGAR_D = "PULGAR_D";
        private readonly string T_MJ_TORSO = "TORSO";
        private readonly string T_MJ_CADERA_C = "CADERA_C";
        private readonly string T_MJ_CADERA_I = "CADERA_I";
        private readonly string T_MJ_RODILLA_I = "RODILLA_I";
        private readonly string T_MJ_TOBILLO_I = "TOBILLO_I";
        private readonly string T_MJ_PIE_I = "PIE_I";
        private readonly string T_MJ_CADERA_D = "CADERA_D";
        private readonly string T_MJ_RODILLA_D = "RODILLA_D";
        private readonly string T_MJ_TOBILLO_D = "TOBILLO_D";
        private readonly string T_MJ_PIE_D = "PIE_D";

        private readonly string TABLA_COORDENADAS = "COORDENADAS";

        private readonly string T_C_ID = "ID_COORDENADAS";
        private readonly string T_C_VERTICE = "VERTICE";
        private readonly string T_C_X = "POSICION_X";
        private readonly string T_C_Y = "POSICION_Y";
        private readonly string T_C_Z = "POSICION_Z";

        public ManejadorTablas(int I, string S)
        {
            //crear la conexion a la base de datos
            SQLiteConnection conexionSeci = new SQLiteConnection("Data Source=" + DATABASE_NAME + ".db");

            conexionSeci.Open();

            SQLiteCommand command = conexionSeci.CreateCommand();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_DATOS_USUARIO + "(" + 
                                    T_DU_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_DU_CODIGO_USUARIO + " VARCHAR(50), " +
                                    T_DU_NOMBRE + " VARCHAR(50), " +
                                    T_DU_APELLIDO + " VARCHAR(50), " +
                                    T_DU_EDAD + " INTEGER, " +
                                    T_DU_ESCOLARIDAD + " VARCHAR(50), " +
                                    T_DU_SEXO + " VARCHAR(50), " +
                                    T_DU_ESTATURA + " DOUBLE, " +
                                    T_DU_PESO + " DOUBLE, " +
                                    T_DU_IMC + " DOUBLE, " +
                                    T_DU_TUTOR + " VARCHAR(50), " +
                                    T_DU_EDAD_TUTOR + " INTEGER, " +
                                    T_DU_TELEFONO_TUTOR + " VARCHAR(50))";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_PARAMETROS_SESION_SECI + "(" +
                                    T_PSS_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_PSS_NUMERO_SESION + " INTEGER, " +
                                    T_PSS_REFORZADOR_TIPO + " VARCHAR(50), " +
                                    T_PSS_REFORZADOR_CLASE + " VARCHAR(50), " +
                                    T_PSS_I_INMEDIATO + " VARCHAR(50), " +
                                    T_PSS_I_DEMORADO + " VARCHAR(50), " +
                                    T_PSS_ESFUERZO_ALTO + " INTEGER, " +
                                    T_PSS_ESFUERZO_BAJO + " INTEGER, " +
                                    T_PSS_P_REF_ALTO + " INTEGER, " +
                                    T_PSS_P_REF_BAJO + " INTEGER, " +
                                    T_PSS_DU_ID + " INTEGER, " +
                                    T_PSS_RSS_ID + " INTEGER, " +
                                    "FOREIGN KEY(" + T_PSS_DU_ID + ")" + " REFERENCES " + TABLA_DATOS_USUARIO + "(" + T_DU_ID + "), " +
                                    "FOREIGN KEY(" + T_PSS_RSS_ID + ")" + " REFERENCES " + TABLA_RESULTADOS_SESION_SECI + "(" + T_RSS_ID + "))";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_RESULTADOS_SESION_SECI + "(" +
                                    T_RSS_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_RSS_TOTAL_PRUEBAS + " INTEGER, " +
                                    T_RSS_I_INMEDIATO + " INTEGER, " +
                                    T_RSS_I_DEMORADO + " INTEGER, " +
                                    T_RSS_ESFUERZO_ALTO + " INTEGER, " +
                                    T_RSS_ESFUERZO_BAJO + " INTEGER, " +
                                    T_RSS_P_REF_ALTO + " INTEGER, " +
                                    T_RSS_P_REF_BAJO + " INTEGER, " +
                                    T_RSS_PIS_ID + " INTEGER, " +
                                    "FOREIGN KEY(" + T_RSS_PIS_ID + ")" + " REFERENCES " + TABLA_PRUEBA_IMAGENES_SECI + "(" + T_PIS_ID + "))";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_PRUEBA_IMAGENES_SECI + "(" +
                                    T_PIS_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_PIS_CALIDAD_ALTA + " INTEGER, " +
                                    T_PIS_CALIDAD_BAJA + " INTEGER)";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_PRUEBA_COMPLETA_SECI + "(" +
                                    T_PCS_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_PCS_NUMERO_PRUEBA + " INTEGER, " +
                                    T_PCS_R_I_INMEDIATO + " INTEGER, " +
                                    T_PCS_R_I_DEMORADO + " INTEGER, " +
                                    T_PCS_ESFUERZO_ALTO + " INTEGER, " +
                                    T_PCS_ESFUERZO_BAJO + " INTEGER, " +
                                    T_PCS_P_REF_ALTO + " INTEGER, " +
                                    T_PCS_P_REF_BAJO + " INTEGER, " +
                                    T_PCS_PSS_ID + " INTEGER, " +
                                    "FOREIGN KEY(" + T_PCS_PSS_ID + ")" + " REFERENCES " + TABLA_PARAMETROS_SESION_SECI + "(" + T_PSS_ID + "))";

            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_ALIMENTACION + "(" +
                                    T_A_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_A_NUMERO_SESION + " INTEGER, " +
                                    T_A_DIA_SEMANA + " VARCHAR(50), " +
                                    T_A_DESAYUNO + " VARCHAR(50), " +
                                    T_A_ALMUERZO + " VARCHAR(50), " +
                                    T_A_COMIDA + " VARCHAR(50), " +
                                    T_A_MERIENDA + " VARCHAR(50), " +
                                    T_A_CENA + " VARCHAR(50), " +
                                    T_A_RUBRICA + " VARCHAR(50), " +
                                    T_A_DU_ID + " INTEGER, " +
                                    "FOREIGN KEY(" + T_A_DU_ID + ")" + " REFERENCES " + TABLA_DATOS_USUARIO + "(" + T_DU_ID + "))";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_LOGROS_SESION_JUEGO + "(" +
                                    T_LSJ_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_LSJ_NUMERO_SESION + " INTEGER, " +
                                    T_LSJ_TIEMPO_JUEGO + " DATETIME, " +
                                    T_LSJ_MONEDAS_RECOLECTADAS + " INTEGER, " +
                                    T_LSJ_NJ_ID + " INTEGER, " +
                                    T_LSJ_MJ_ID + " INTEGER, " +
                                    T_LSJ_AI_ID + " INTEGER, " +
                                    T_LSJ_LTJ_ID + " INTEGER, " +
                                    T_LSJ_DU_ID + " INTEGER, " +
                                    "FOREIGN KEY(" + T_LSJ_NJ_ID + ")" + " REFERENCES " + TABLA_NIVELES_JUEGO + "(" + T_NJ_ID + "), " +
                                    "FOREIGN KEY(" + T_LSJ_MJ_ID + ")" + " REFERENCES " + TABLA_MOVIMIENTOS_JUEGO + "(" + T_MJ_ID + "), " +
                                    "FOREIGN KEY(" + T_LSJ_AI_ID + ")" + " REFERENCES " + TABLA_ACTUAL_IMC + "(" + T_AI_ID + "), " +
                                    "FOREIGN KEY(" + T_LSJ_LTJ_ID + ")" + " REFERENCES " + TABLA_LOGROS_TOTAL_JUEGO + "(" + T_LTJ_ID + "), " +
                                    "FOREIGN KEY(" + T_LSJ_DU_ID + ")" + " REFERENCES " + TABLA_DATOS_USUARIO + "(" + T_DU_ID + "))";

            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_ACTUAL_IMC + "(" +
                                    T_AI_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_AI_ESTATURA + " DOUBLE, " +
                                    T_AI_PESO + " DOUBLE, " +
                                    T_AI_IMC_ACTUAL + " DOUBLE)";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_LOGROS_TOTAL_JUEGO + "(" +
                                    T_LTJ_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_LTJ_TOTAL_SESIONES + " INTEGER, " +
                                    T_LTJ_TOTAL_TIEMPO_JUEGO + " DATETIME, " +
                                    T_LTJ_TOTAL_MONEDAS_RECOLECTADAS + " INTEGER, " +
                                    T_LTJ_TOTAL_NIVELES + " INTEGER)";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_NIVELES_JUEGO + "(" +
                                    T_NJ_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_NJ_NIVEL + " INTEGER, " +
                                    T_NJ_SUB_1 + " INTEGER, " +
                                    T_NJ_SUB_2 + " INTEGER, " +
                                    T_NJ_SUB_3 + " INTEGER, " +
                                    T_NJ_SUB_4 + " INTEGER, " +
                                    T_NJ_SUB_5 + " INTEGER, " +
                                    T_NJ_SUB_6 + " INTEGER, " +
                                    T_NJ_SUB_7 + " INTEGER, " +
                                    T_NJ_SUB_8 + " INTEGER, " +
                                    "FOREIGN KEY(" + T_NJ_SUB_1 + ", " + T_NJ_SUB_2 + ", " + T_NJ_SUB_3 + ", " + 
                                                    T_NJ_SUB_4 + ", " + T_NJ_SUB_5 + ", " + T_NJ_SUB_6 + ", " + 
                                                    T_NJ_SUB_7 + ", " + T_NJ_SUB_8 + ")" + " REFERENCES " + 
                                                    TABLA_MOVIMIENTOS_JUEGO +
                                                    "(" + T_MJ_ID + ", " + T_MJ_ID + ", " + T_MJ_ID + ", " +
                                                      T_MJ_ID + ", " + T_MJ_ID + ", " + T_MJ_ID + ", " +
                                                       T_MJ_ID + ", " + T_MJ_ID + "))";

            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                    TABLA_MOVIMIENTOS_JUEGO + "(" +
                                    T_MJ_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    T_MJ_SUB_NIVEL + " INTEGER, " +
                                    T_MJ_CABEZA + " INTEGER, " +
                                    T_MJ_CUELLO + " INTEGER, " +
                                    T_MJ_HOMBRO_C + " INTEGER, " +
                                    T_MJ_HOMBRO_I + " INTEGER, " +
                                    T_MJ_CODO_I + " INTEGER, " +
                                    T_MJ_MUÑECA_I + " INTEGER, " +
                                    T_MJ_MANO_I + " INTEGER, " +
                                    T_MJ_DEDOS_I + " INTEGER, " +
                                    T_MJ_PULGAR_I + " INTEGER, " +
                                    T_MJ_HOMBRO_D + " INTEGER, " +
                                    T_MJ_CODO_D + " INTEGER, " +
                                    T_MJ_MUÑECA_D + " INTEGER, " +
                                    T_MJ_MANO_D + " INTEGER, " +
                                    T_MJ_DEDOS_D + " INTEGER, " +
                                    T_MJ_PULGAR_D + " INTEGER, " +
                                    T_MJ_TORSO + " INTEGER, " +
                                    T_MJ_CADERA_C + " INTEGER, " +
                                    T_MJ_CADERA_I + " INTEGER, " +
                                    T_MJ_RODILLA_I + " INTEGER, " +
                                    T_MJ_TOBILLO_I + " INTEGER, " +
                                    T_MJ_PIE_I + " INTEGER, " +
                                    T_MJ_CADERA_D + " INTEGER, " +
                                    T_MJ_RODILLA_D + " INTEGER, " +
                                    T_MJ_TOBILLO_D + " INTEGER, " +
                                    T_MJ_PIE_D + " INTEGER, " +
                                    "FOREIGN KEY(" + T_MJ_CABEZA + ", " + T_MJ_CUELLO + ", " + T_MJ_HOMBRO_C + ", " +
                                                    T_MJ_HOMBRO_I + ", " + T_MJ_CODO_I + ", " + T_MJ_MUÑECA_I + ", " +
                                                    T_MJ_MANO_I + ", " + T_MJ_DEDOS_I + ", " + T_MJ_PULGAR_I + ", " +
                                                    T_MJ_HOMBRO_D + ", " + T_MJ_CODO_D + ", " + T_MJ_MUÑECA_D + ", " +
                                                    T_MJ_MANO_D + ", " + T_MJ_DEDOS_D + ", " + T_MJ_PULGAR_D + ", " +
                                                    T_MJ_TORSO + ", " + T_MJ_CADERA_C + ", " + T_MJ_CADERA_I + ", " +
                                                    T_MJ_RODILLA_I + ", " + T_MJ_TOBILLO_I + ", " + T_MJ_PIE_I + ", " +
                                                    T_MJ_CADERA_D + ", " + T_MJ_RODILLA_D + ", " + T_MJ_TOBILLO_D + ", " +
                                                    T_MJ_PIE_D + ")" + " REFERENCES " +
                                                    TABLA_COORDENADAS +
                                                    "(" + T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                      T_C_ID + ", " + T_C_ID + ", " + T_C_ID + ", " +
                                                       T_C_ID + "))";
            //execute SQL query
            command.ExecuteNonQuery();
            //Crear las tablas
            command.CommandText = "CREATE TABLE IF NOT EXISTS " +
                                        TABLA_COORDENADAS + "(" +
                                        T_C_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                        T_C_VERTICE + " VARCHAR(50), " +
                                        T_C_X + " DOUBLE, " +
                                        T_C_Y + " DOUBLE, " +
                                        T_C_Z + " DOUBLE)";
            //execute SQL query
            command.ExecuteNonQuery();

            //Inserting data
            command.CommandText = "INSERT INTO " + TABLA_DATOS_USUARIO + "( " + 
                                    T_DU_ID + ", " + T_DU_NOMBRE + ", " + T_DU_APELLIDO + ", " + T_DU_CODIGO_USUARIO +
                                    " ) VALUES (NULL, '" + S + "', '" + S + "', '" + S + "')";
            //execute SQL query
            command.ExecuteNonQuery();

            //Inserting data
            command.CommandText = "INSERT INTO " + TABLA_DATOS_USUARIO + "( " +
                                    T_DU_ID + ", " + T_DU_NOMBRE + ", " + T_DU_APELLIDO + ", " + T_DU_CODIGO_USUARIO +
                                    " ) VALUES (NULL, '" + S + "', '" + S + "', '" + S + "')";
            //execute SQL query
            command.ExecuteNonQuery();

            //table Update
            command.CommandText = "UPDATE "+ TABLA_DATOS_USUARIO + 
                                    " SET " + T_DU_NOMBRE + "='Feliz' WHERE " + T_DU_ID + " = 2";
            command.ExecuteNonQuery();
 
            //Read from table
            command.CommandText = "SELECT * FROM " + TABLA_DATOS_USUARIO;
            //Data Reader Object
            SQLiteDataReader sdr = command.ExecuteReader();
            // Read() returns true if there is still a result line to read
            while (sdr.Read())
            {
                string myreader = sdr.GetString(2);                
                MessageBox.Show(myreader);
            }

            sdr.Close();
 
            //Delete Record
            command.CommandText = "DELETE FROM "+ TABLA_DATOS_USUARIO +
                                    " WHERE " + T_DU_ID + "=1";
            command.ExecuteNonQuery();

            conexionSeci.Close();
        }
    }
}
