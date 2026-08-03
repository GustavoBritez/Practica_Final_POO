namespace Final
{
    public interface ISujeto
    {
        void AgregarObservador(IObservador observador);
        void QuitarObservador(IObservador observador);
        void Notificar();
    }
}
