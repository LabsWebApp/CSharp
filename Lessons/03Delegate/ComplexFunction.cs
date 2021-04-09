namespace Delegate
{
    //delegate void VoidFunction(ref int sender, int arg = default);
    delegate void VoidFunction(ref object sender, object arg = default);
    
    delegate VoidFunction ComplexVoidFunction(
        VoidFunction component1 = default,
        VoidFunction component2 = default);
}
