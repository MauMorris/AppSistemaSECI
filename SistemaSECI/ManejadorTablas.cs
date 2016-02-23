using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSECI
{ 
    class ManejadorTablas
    {
        private string DATA_BASE_NAME = "SECI";

        private string VS_TABLA_DATOS_USUARIO = "TABLA DE DATOS DE USUARIO";

        private string VS_T_DU_ID ="ID";
        private string VS_T_DU_NOMBRE ="NOMBRE";
        private string VS_T_DU_APELLIDO ="APELLIDO";
        private string VS_T_DU_EDAD ="EDAD";
        private string VS_T_DU_ESCOLARIDAD ="ESCOLARIDAD";
        private string VS_T_DU_SEXO ="SEXO";
        private string VS_T_DU_ESTATURA ="ESTATURA";
        private string VS_T_DU_PESO ="PESO";
        private string VS_T_DU_IMC ="IMC";
        private string VS_T_DU_TUTOR ="TUTOR";
        private string VS_T_DU_EDAD_TUTOR ="EDAD TUTOR";
        private string VS_T_DU_TELEFONO ="TELEFONO";

        private string VS_TABLA_PARAMETROS_SESION = "TABLA DE PARAMETROS POR SESION";

        private string VS_T_PAS_ID ="ID";
        private string VS_T_PAS_NUM_SESION ="NUMERO DE SESION";
        private string VS_T_PAS_REFORZADOR_TIPO ="TIPO DE REFORZADOR";
        private string VS_T_PAS_REFORZADOR_CLASE ="CLASE DE REFORZADOR";
        private string VS_T_PAS_I_INMEDIATO ="INMEDIATEZ INMEDIATO";
        private string VS_T_PAS_I_DEMORADO ="INMEDIATEZ DEMORADO";
        private string VS_T_PAS_ESFUERZO_ALTO ="ESFUERZO ALTO";
        private string VS_T_PAS_ESFUERZO_BAJO ="ESFUERZO BAJO";
        private string VS_T_PAS_P_REF_ALTO ="PROGRAMA DE REFORZAMIENTO ALTO";
        private string VS_T_PAS_P_REF_BAJO ="PROGRAMA DE REFORZAMIENTO BAJO";

        private string VS_TABLA_PRUEBAS_SESION = "TABLA DE PRUEBAS POR SESION";

        private string VS_T_PRS_ID = "ID";
        private string VS_T_PRS_NUM_SESION = "NUMERO DE SESION";
        private string VS_T_PRS_NUM_PRUEBA = "NUMERO DE PRUEBA";
        private string VS_T_PRS_REFORZADOR_TIPO = "TIPO DE REFORZADOR";
        private string VS_T_PRS_REFORZADOR_CLASE = "CLASE DE REFORZADOR";
        private string VS_T_PRS_I_INMEDIATO = "INMEDIATEZ INMEDIATO";
        private string VS_T_PRS_I_DEMORADO = "INMEDIATEZ DEMORADO";
        private string VS_T_PRS_ESFUERZO_ALTO = "ESFUERZO ALTO";
        private string VS_T_PRS_ESFUERZO_BAJO = "ESFUERZO BAJO";
        private string VS_T_PRS_P_REF_ALTO = "PROGRAMA DE REFORZAMIENTO ALTO";
        private string VS_T_PRS_P_REF_BAJO = "PROGRAMA DE REFORZAMIENTO BAJO";

        private string VS_TABLA_RESULTADOS_PRUEBAS_SESION = "TABLA DE RESULTADOS DE PRUEBAS POR SESION";

        private string VS_T_REPS_ID = "ID";
        private string VS_T_REPS_NUM_SESION = "NUMERO DE SESION";
        private string VS_T_REPS_NUM_PRUEBA = "SUMA TOTAL DE PRUEBA";
        private string VS_T_REPS_REFORZADOR_TIPO = "TIPO DE REFORZADOR";
        private string VS_T_REPS_REFORZADOR_CLASE = "CLASE DE REFORZADOR";
        private string VS_T_REPS_I_INMEDIATO = "INMEDIATEZ INMEDIATO";
        private string VS_T_REPS_I_DEMORADO = "INMEDIATEZ DEMORADO";
        private string VS_T_REPS_ESFUERZO_ALTO = "ESFUERZO ALTO";
        private string VS_T_REPS_ESFUERZO_BAJO = "ESFUERZO BAJO";
        private string VS_T_REPS_P_REF_ALTO = "PROGRAMA DE REFORZAMIENTO ALTO";
        private string VS_T_REPS_P_REF_BAJO = "PROGRAMA DE REFORZAMIENTO BAJO";

        private string VJ_TABLA_LOGROS_SESION = "TABLA DE LOGROS POR SESION";

        private string VJ_T_LS_ID = "ID";
        private string VJ_T_LS_NUM_SESION = "NUMERO DE SESION";
        private string VJ_T_LS_TIEMPO_JUEGO = "TIEMPO DE JUEGO";
        private string VJ_T_LS_MONEDAS_RECOLECTADAS = "MONEDAS RECOLECTADAS";
        private string VJ_T_LS_NIVEL_JUEGO = "NIVEL DE JUEGO";
        private string VJ_T_LS_PESO = "PESO";
        private string VJ_T_LS_ESTATURA = "ESTATURA";
        private string VJ_T_LS_IMC = "IMC";

        private string VJ_TABLA_LOGROS = "TABLA DE LOGROS";

        private string VJ_T_L_ID = "ID";
        private string VJ_T_L_NUM_SESIONES = "NUMERO DE SESIONES";
        private string VJ_T_L_TIEMPO_JUEGO = "TIEMPO DE JUEGO TOTAL";
        private string VJ_T_L_MONEDAS_RECOLECTADAS = "MONEDAS RECOLECTADAS TOTALES";
        private string VJ_T_L_NIVEL_JUEGO = "NIVEL DE JUEGO FINAL";
        private string VJ_T_L_PESO = "PESO FINAL";
        private string VJ_T_L_ESTATURA = "ESTATURA FINAL";
        private string VJ_T_L_IMC = "IMC FINAL";

        private string VA_TABLA_DATOS_ALIMENTACION = "TABLA DE DATOS DE ALIMENTACION";

        private string VA_T_DA_ID = "ID";
        private string VA_T_DA_SESIONES = "NUMERO DE SESIONES";
        private string VA_T_DA_LUNES = "LUNES";
        private string VA_T_DA_MARTES = "MARTES";
        private string VA_T_DA_MIERCOLES = "MIERCOLES";
        private string VA_T_DA_JUEVES = "JUEVES";
        private string VA_T_DA_VIERNES = "VIERNES";
        private string VA_T_DA_SABADO = "SABADO";
        private string VA_T_DA_DOMINGO = "DOMINGO";

        private string VA_TABLA_DATOS_ALIMENTACION_LUNES = "TABLA DE ALIMENTOS LUNES";

        private string VA_T_DAL_ID = "ID";
        private string VA_T_DAL_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAL_LUNES = "LUNES";
        private string VA_T_DAL_DESAYUNO = "DESAYUNO";
        private string VA_T_DAL_ALMUERZO = "ALMUERZO";
        private string VA_T_DAL_COMIDA = "COMIDA";
        private string VA_T_DAL_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_MARTES = "TABLA DE ALIMENTOS MARTES";

        private string VA_T_DAM_ID = "ID";
        private string VA_T_DAM_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAM_MARTES = "MARTES";
        private string VA_T_DAM_DESAYUNO = "DESAYUNO";
        private string VA_T_DAM_ALMUERZO = "ALMUERZO";
        private string VA_T_DAM_COMIDA = "COMIDA";
        private string VA_T_DAM_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_MIERCOLES = "TABLA DE ALIMENTOS MIERCOLES";

        private string VA_T_DAMI_ID = "ID";
        private string VA_T_DAMI_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAMI_MIERCOLES = "MIERCOLES";
        private string VA_T_DAMI_DESAYUNO = "DESAYUNO";
        private string VA_T_DAMI_ALMUERZO = "ALMUERZO";
        private string VA_T_DAMI_COMIDA = "COMIDA";
        private string VA_T_DAMI_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_JUEVES = "TABLA DE ALIMENTOS JUEVES";

        private string VA_T_DAJ_ID = "ID";
        private string VA_T_DAJ_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAJ_JUEVES = "JUEVES";
        private string VA_T_DAJ_DESAYUNO = "DESAYUNO";
        private string VA_T_DAJ_ALMUERZO = "ALMUERZO";
        private string VA_T_DAJ_COMIDA = "COMIDA";
        private string VA_T_DAJ_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_VIERNES = "TABLA DE ALIMENTOS VIERNES";

        private string VA_T_DAV_ID = "ID";
        private string VA_T_DAV_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAV_VIERNES = "VIERNES";
        private string VA_T_DAV_DESAYUNO = "DESAYUNO";
        private string VA_T_DAV_ALMUERZO = "ALMUERZO";
        private string VA_T_DAV_COMIDA = "COMIDA";
        private string VA_T_DAV_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_SABADO = "TABLA DE ALIMENTOS SABADO";

        private string VA_T_DAS_ID = "ID";
        private string VA_T_DAS_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAS_SABADO = "SABADO";
        private string VA_T_DAS_DESAYUNO = "DESAYUNO";
        private string VA_T_DAS_ALMUERZO = "ALMUERZO";
        private string VA_T_DAS_COMIDA = "COMIDA";
        private string VA_T_DAS_CENA = "CENA";

        private string VA_TABLA_DATOS_ALIMENTACION_DOMINGO = "TABLA DE ALIMENTOS DOMINGO";

        private string VA_T_DAD_ID = "ID";
        private string VA_T_DAD_NUM_SESION = "NUMERO DE SESION";
        private string VA_T_DAD_DOMINGO = "DOMINGO";
        private string VA_T_DAD_DESAYUNO = "DESAYUNO";
        private string VA_T_DAD_ALMUERZO = "ALMUERZO";
        private string VA_T_DAD_COMIDA = "COMIDA";
        private string VA_T_DAD_CENA = "CENA";

    }
}
