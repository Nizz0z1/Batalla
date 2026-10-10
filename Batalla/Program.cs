using System;

// ===================== CLASE PERSONAJE =====================
class Personaje
{
    // Atributos
    public string nombre;
    public int vida;
    public int nivel;
    public int ataque;

    // Constructor 1: sin parámetros (valores predeterminados)
    public Personaje()
    {
        nombre = "Desconocido";
        vida = 100;
        nivel = 1;
        ataque = 10;
    }

    // Constructor 2: solo recibe el nombre
    public Personaje(string nombre)
    {
        this.nombre = nombre;
        vida = 100;
        nivel = 1;
        ataque = 10;
    }

    // Constructor 3: recibe todos los datos
    public Personaje(string nombre, int vida, int nivel, int ataque)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.nivel = nivel;
        this.ataque = ataque;
    }

    // Muestra los datos actuales del personaje
    public void MostrarInformacion()
    {
        Console.WriteLine(nombre);
        Console.WriteLine("Vida: " + vida);
        Console.WriteLine("Nivel: " + nivel);
        Console.WriteLine("Ataque: " + ataque);
        Console.WriteLine();
    }

    // Disminuye la vida, sin bajar de 0
    public void RecibirDanio(int cantidad)
    {
        vida = vida - cantidad;

        if (vida < 0)
        {
            vida = 0;
        }

        Console.WriteLine(nombre + " recibió " + cantidad + " puntos de daño.");
    }

    // Aumenta la vida
    public void Curar(int cantidad)
    {
        vida = vida + cantidad;
        Console.WriteLine(nombre + " recuperó " + cantidad + " puntos de vida.");
    }

    // Sube 1 nivel y 5 puntos de ataque
    public void SubirNivel()
    {
        nivel = nivel + 1;
        ataque = ataque + 5;
        Console.WriteLine(nombre + " subió de nivel.");
    }

    // Ataca a otro personaje: el enemigo pierde vida igual al ataque de este personaje
    public void Atacar(Personaje enemigo)
    {
        Console.WriteLine(nombre + " atacó a " + enemigo.nombre + ".");
        enemigo.RecibirDanio(ataque);
    }

    // Retorna la vida actual
    public int ObtenerVida()
    {
        return vida;
    }

    // Retorna true si la vida es mayor a 0
    public bool EstaVivo()
    {
        return vida > 0;
    }
}

// ===================== PROGRAMA PRINCIPAL =====================
class Program
{
    // Espera a que el usuario presione ENTER para continuar
    static void Pausar()
    {
        Console.WriteLine("(Presiona ENTER para continuar...)");
        Console.ReadLine();
        Console.WriteLine();
    }

    static void Main()
    {
        // Creación de objetos con los tres constructores
        Personaje kratos = new Personaje("Kratos", 100, 1, 20);   // Constructor 3
        Personaje link = new Personaje("Link");                    // Constructor 2
        Personaje desconocido = new Personaje();                   // Constructor 1

        Console.WriteLine("=== ESTADO INICIAL ===\n");
        kratos.MostrarInformacion();
        link.MostrarInformacion();
        desconocido.MostrarInformacion();
        Pausar();

        Console.WriteLine("=== COMBATE ===\n");

        kratos.Atacar(link);
        Pausar();

        link.Atacar(kratos);
        Pausar();

        desconocido.Atacar(link);
        Pausar();

        kratos.Curar(10);
        Pausar();

        link.SubirNivel();
        Pausar();

        Console.WriteLine("=== ESTADO FINAL ===\n");
        kratos.MostrarInformacion();
        link.MostrarInformacion();
        desconocido.MostrarInformacion();
        Pausar();

        Console.WriteLine("=== VERIFICACIÓN ===\n");

        if (kratos.EstaVivo())
            Console.WriteLine(kratos.nombre + " sigue con vida (" + kratos.ObtenerVida() + " de vida).");
        else
            Console.WriteLine(kratos.nombre + " ha sido derrotado.");

        if (link.EstaVivo())
            Console.WriteLine(link.nombre + " sigue con vida (" + link.ObtenerVida() + " de vida).");
        else
            Console.WriteLine(link.nombre + " ha sido derrotado.");

        if (desconocido.EstaVivo())
            Console.WriteLine(desconocido.nombre + " sigue con vida (" + desconocido.ObtenerVida() + " de vida).");
        else
            Console.WriteLine(desconocido.nombre + " ha sido derrotado.");

        Console.WriteLine("\nFin de la batalla. Presiona ENTER para salir...");
        Console.ReadLine();
    }
}