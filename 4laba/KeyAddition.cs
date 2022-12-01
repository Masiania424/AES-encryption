namespace _4laba
{
    partial class AEScrypt
    {
        public static AEScrypt KeyAddition(AEScrypt matrix)
        {
            string[] firstRoundKey = new string[4] { "00", "00", "00", "01" };
            string[] functionMatrix = new string[4];

            string[,] result = new string[4, 4];

            for (int i = 0; i < 4; i++)
            {
                functionMatrix[i] = ByteSubstitution[Convert.ToInt32(matrix.Matrix[i, 3][0].ToString(), 16), Convert.ToInt32(matrix.Matrix[i, 3][1].ToString(), 16)];

                functionMatrix[i] = XORoperation(HexToBinary(functionMatrix[i][0].ToString(), functionMatrix[i][1].ToString()), HexToBinary(firstRoundKey[i][0].ToString(), firstRoundKey[i][1].ToString()));

                functionMatrix[i] = Convert.ToString(Convert.ToInt32(functionMatrix[i][..4], 2), 16).ToUpper() + Convert.ToString(Convert.ToInt32(functionMatrix[i][4..], 2), 16).ToUpper();
            }
            Array.Reverse(functionMatrix);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0)
                    {
                        result[j, i] = XORoperation(HexToBinary(functionMatrix[j][0].ToString(), functionMatrix[j][1].ToString()), HexToBinary(matrix.Matrix[j, i][0].ToString(), matrix.Matrix[j, i][1].ToString()));
                        result[j, i] = Convert.ToString(Convert.ToInt32(result[j, i][..4], 2), 16).ToUpper() + Convert.ToString(Convert.ToInt32(result[j, i][4..], 2), 16).ToUpper();
                    }
                    else
                    {
                        result[j, i] = XORoperation(HexToBinary(matrix.Matrix[j, i][0].ToString(), matrix.Matrix[j, i][1].ToString()), HexToBinary(result[j, i - 1][0].ToString(), result[j, i - 1][1].ToString()));
                        result[j, i] = Convert.ToString(Convert.ToInt32(result[j, i][..4], 2), 16).ToUpper() + Convert.ToString(Convert.ToInt32(result[j, i][4..], 2), 16).ToUpper();
                    }
                }
            }
            return new AEScrypt(TwoNum(result));
        }
    }
}
