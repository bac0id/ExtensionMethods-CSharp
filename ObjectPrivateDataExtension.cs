using System;
using System.Reflection;

/// <summary>
/// Object extensions for private data.
/// </summary>
public static class ObjectPrivateDataExtension
{
	/// <summary>
	/// Get a private field.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance">Instance, keep <see cref="null"/> if it's static.</param>
	/// <param name="fieldName">The name of the field.</param>
	/// <returns></returns>
	public static T GetPrivateField<T>(this object instance, string fieldName) {
		Type type = instance.GetType();
		BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
		FieldInfo field = type.GetField(fieldName, flag);
		return (T)field.GetValue(instance);
	}
	/// <summary>
	/// Get a private property.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="instance">Instance, keep <see cref="null"/> if it's static.</param>
	/// <param name="propertyName">The name of the property.</param>
	/// <returns></returns>
	public static T GetPrivateProperty<T>(this object instance, string propertyName) {
		Type type = instance.GetType();
		BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
		PropertyInfo field = type.GetProperty(propertyName, flag);
		return (T)field.GetValue(instance, null);
	}
	/// <summary>
	/// Set a private field.
	/// </summary>
	/// <param name="instance">Instance, keep <see cref="null"/> if it's static.</param>
	/// <param name="fieldName">The name of the field.</param>
	/// <param name="value">The new value.</param>
	public static void SetPrivateField(this object instance, string fieldName, object value) {
		Type type = instance.GetType();
		BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
		FieldInfo field = type.GetField(fieldName, flag);
		field.SetValue(instance, value);
	}
	/// <summary>
	/// Set a private property.
	/// </summary>
	/// <param name="instance">Instance, keep <see cref="null"/> if it's static.</param>
	/// <param name="propertyName">The name of the property.</param>
	/// <param name="value">The new value.</param>
	public static void SetPrivateProperty(this object instance, string propertyName, object value) {
		Type type = instance.GetType();
		BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
		PropertyInfo field = type.GetProperty(propertyName, flag);
		field.SetValue(instance, value, null);
	}
	/// <summary>
	/// Call a private method.
	/// </summary>
	/// <typeparam name="T">The type of its return value.</typeparam>
	/// <param name="instance">Instance, keep <see cref="null"/> if it's static.</param>
	/// <param name="name">The name of the method.</param>
	/// <param name="param">The arguments.</param>
	/// <returns></returns>
	public static T CallPrivateMethod<T>(this object instance, string name, params object[] param) {
		Type type = instance.GetType();
		BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
		MethodInfo method = type.GetMethod(name, flag);
		return (T)method.Invoke(instance, param);
	}
}