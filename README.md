# Hue-Process-Killer
Un pequeño programa que escanea los procesos cada 10 segundos en busca del que el usuario especifique y lo cierra

El proceso requerido se pone en el Program.cs, justo en la linea 68 en:
'''
        string nombreProceso = args.Length > 0 ? args[0] : "eclipse";
'''
"eclipse" solo es el nombre del proceso para el que lo diseñe originalmente.
Para consultar el nombre del proceso requerido recomiendo verlo en el administrador de tareas
Y por cierto, este codigo necesita .NET
