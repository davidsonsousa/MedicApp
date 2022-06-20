namespace MedicApp.SharedKernel;

public static class Constants
{
    public static class DebugMessages
    {
        public const string ClassMethodObjectValue = "{className} > {methodName}({objectName}): {objectValue}";
        public const string ClassMethod = "{className} > {methodName}";
        public const string MethodObjectValue = "{methodName}({objectName}): {objectValue}";
        public const string Method = "{methodName}()";
    }

    public static class Discriminator
    {
        public const string Doctor = "Doctor";
        public const string Nurse = "Nurse";
        public const string Patient = "Patient";
    }

    public static class ModalButtons
    {
        public const string Yes = "Yes";
        public const string No = "No";
        public const string Ok = "Ok";
        public const string Cancel = "Cancel";
    }
}
