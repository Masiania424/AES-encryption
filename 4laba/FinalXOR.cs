namespace _4laba
{
    partial class AEScrypt
    {
        public static AEScrypt FinalXOR(AEScrypt result, AEScrypt key)
        {
            result.Matrix = TwoNum(result.Matrix);
            key.Matrix = TwoNum(key.Matrix);

            string[,] matrix = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var temp = XORoperation(HexToBinary(result.Matrix[i, j][0].ToString(), result.Matrix[i, j][1].ToString()), HexToBinary(key.Matrix[i, j][0].ToString(), key.Matrix[i, j][1].ToString()));
                    temp = Convert.ToString(Convert.ToInt32(temp[..4], 2), 16).ToUpper() + Convert.ToString(Convert.ToInt32(temp[4..], 2), 16).ToUpper();
                    matrix[i, j] = temp;
                }
            }
            return new AEScrypt(TwoNum(matrix));
        }
    }
}
