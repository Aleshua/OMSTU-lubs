namespace SpaceBattle.Lib
{
    public class Vector
    {
        public int[] vector;
        public int Size;
        
        public Vector(params int[] array){
            Size = array.Length;
            vector = new int[Size];
            for(int i = 0;i < Size;i++){
                vector[i] = array[i];
            }
        }

        public override bool Equals(object? obj){
            if (obj is Vector item)
            {
                return this == item;
            }
    return false;
        }


        public override int GetHashCode(){
            return HashCode.Combine(vector);
        }
        
        public override string ToString(){  
            string stroka = "Vector(";
            
            for (int i = 0; i < Size - 1; i++){
                stroka += vector[i] + ", ";
            }
            
            stroka += vector[Size - 1] + ")";
            
            return stroka;
        }
        
        public int this[int index]{
            get {
                return vector[index];
            }
            set {
                vector[index] = value;
            }
        }
        
        public static Vector operator + (Vector x, Vector y){
            if (x.Size != y.Size){ 
                throw new System.ArgumentException();
            }
            else {
                int[] newvector = new int[x.Size];
                
                for (int i = 0; i < x.Size; i++){ 
                    newvector[i] = x[i] + y[i];
                }
                return new Vector(newvector);
            }
        }
        
        public static Vector operator - (Vector x, Vector y){
            if (x.Size != y.Size){ 
                throw new System.ArgumentException();
            }
            else {
                int[] newvector = new int[x.Size];
                
                for (int i = 0; i < x.Size; i++){ 
                    newvector[i] = x[i] - y[i];
                }
                return new Vector(newvector);
            }
        }
        
        public static Vector operator * (int n, Vector x){
            int[] newvector = new int[x.Size];
            
            for (int i = 0; i < x.Size; i++){ 
                newvector[i] = n * x[i];
            }
            return new Vector(newvector);
        }
        
        public static bool operator == (Vector x, Vector y){
            if (x.Size != y.Size){
                return false;
            }
            else {
                for (int i = 0; i < x.Size; i++){
                    if (x[i] != y[i]){
                        return false;
                    }
                }
                return true;
            }
        }
        
        public static bool operator != (Vector x, Vector y){
            if (x == y){
                return false;    
            }
            return true;
        }
        
        public static bool operator < (Vector x, Vector y){

            if (x == y){
                return false;
            }
            
            if (x.Size > y.Size){
                return false;
            }
            return true;

        }


        public static bool operator > (Vector x, Vector y){ 
            return y < x;
        }

    }
}