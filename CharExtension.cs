public static class CharExtensions
{
	public static bool IsChinese(this char ch) {
		char c1 = '一';
		char c2 = '龥';
		return ch.CompareTo(c1) * ch.CompareTo(c2) <= 0;
	}

	public static bool IsChinesePunctuation(this char ch) {
		if (ch == '，' || ch == '。' || ch == '！' || ch == '？' || ch == '；' || ch == '：' || ch == '、' || ch == '‧') {
			return true;
		}
		return false;
	}
}
