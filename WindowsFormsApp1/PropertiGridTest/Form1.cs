using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertiGridTest
{
    public partial class Form1 : Form
    {
        private people people;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            people = new people();
            propertyGrid1.SelectedObject = people;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            people.GetPeopleList.Add(DateTime.Now.ToString());
        }
    }

    //[TypeConverter(typeof(ListExpandableConverter))]
    public class people
    {
        public people()
        {
            peopleList = new List<string>();

            peopleList.Add("A");
            peopleList.Add("B");
            peopleList.Add("C");

        }

        private string _changeableParent;

        /// <summary>
        /// Get/Set for ChangeableParent
        /// </summary>
        [DefaultValue("")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [DataList("GetPeopleList")]
        [Category("Misc"), Description("Description of ChooseParent"), DisplayName("Choose a Parent")]
        public string ChooseParent
        {
            get { return (_changeableParent); }
            set { _changeableParent = value; }
        }

        private List<string> peopleList;
        public List<string> GetPeopleList
        {
            get
            {
                return peopleList;
            }

            set
            {
                peopleList = value;
            }
        }
    }


    public class ListGridComboBox : GridComboBox
    {
        #region Methods - Private

        /// <summary>
        /// Create a new object and send notification if requested
        /// </summary>
        /// <param name="context"></param>
        /// <returns>An instantiated object</returns>
        private object CreateNewObject(ITypeDescriptorContext context)
        {
            object obj = null;

            DataListAttribute attribute = base.ListAttribute as DataListAttribute;
            if ((attribute != null) && (attribute.AddNew))
            {
                obj = Reflect.CreateInstance(context.PropertyDescriptor.PropertyType, null);
                SendOnAddNotification(context, obj);
            }

            return (obj);
        }

        /// <summary>
        /// Send notification of object creation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="obj"></param>
        private void SendOnAddNotification(ITypeDescriptorContext context, object obj)
        {
            DataListAttribute attribute = base.ListAttribute as DataListAttribute;
            if ((obj != null) && (attribute != null) && (attribute.EventHandler != null))
            {
                ObjectCreatedEventArgs arg = new ObjectCreatedEventArgs(obj);
                Reflect.CallMethod(context.Instance, attribute.EventHandler, this, arg);
            }
        }


        /// <summary>
        /// Get the class instance of a field/property/method
        /// </summary>
        /// <param name="path"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private static object GetLocalProperty(IEnumerable<string> path, object property)
        {
            foreach (string segment in path)
            {
                Property propertyInfo = PathParser.BreakVariable(segment);
                property = Reflect.CallGeneric(property, propertyInfo.Name);

                // If there was a subscript get the data object
                if ((property is IList) && (propertyInfo.Index != null))
                {
                    if (property is IDictionary)
                    {
                        property = ((IDictionary)property)[propertyInfo.Index];
                    }
                    else
                    {
                        property = ((IList)property)[(int)propertyInfo.Index];
                    }
                }
            }

            return property;
        }

        /// <summary>
        /// Get the static field/property/method of the class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static object GetStaticProperty(DataListAttribute attribute, IList<string> path)
        {
            Type type;
            object property;
            string segment;
            int count = 0;

            type = ClassType.GetType(attribute.DllName, attribute.ClassName);

            segment = path[count++];
            property = Reflect.GetStaticDataMember(type, segment);


            for (; count < path.Count; count++)
            {
                segment = path[count];

                Property propertyInfo = PathParser.BreakVariable(segment);
                property = Reflect.GetDataMember(property, propertyInfo.Name);

                // If there was a subscript get the data object
                if (propertyInfo.Index != null)
                {
                    if (property is IDictionary)
                    {
                        property = ((IDictionary)property)[propertyInfo.Index];
                    }
                    else if (property is IList)
                    {
                        property = ((IList)property)[(int)propertyInfo.Index];
                    }
                }
            }

            return property;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Get the object selected and create a new object if <Add New...> was selected
        /// </summary>
        /// <returns></returns>
        protected override object GetDataObjectSelected(ITypeDescriptorContext context)
        {
            object dataObject = base.ListBox.SelectedItem;

            if ((dataObject is string) && (dataObject.Equals("<Add New...>")))
            {
                return (CreateNewObject(context));
            }

            return (dataObject);
        }


        /// <summary>
        /// Find the list of data to populate the ListBox with
        /// </summary>
        /// <param name="context"></param>
        protected override void RetrieveDataList(ITypeDescriptorContext context)
        {
            DataListAttribute dataListAttribute = null;
            object property = null;

            // Find the Attribute that has the path to the List of Items
            foreach (Attribute attribute in context.PropertyDescriptor.Attributes)
            {
                if (attribute is DataListAttribute)
                {
                    dataListAttribute = attribute as DataListAttribute;
                    base.ListAttribute = dataListAttribute;
                    break;
                }
            }

            // If we found the Attribute, find the Data List
            if (dataListAttribute != null)
            {
                // Split the path 
                List<string> path = PathParser.GetPathParts(dataListAttribute.Path);

                // The path has 1 or more parts
                if ((path != null) && (path.Count > 0))
                {
                    if (dataListAttribute.IsStatic)
                    {
                        property = GetStaticProperty(dataListAttribute, path);
                    }
                    else
                    {
                        // Set the property to the current object
                        property = GetLocalProperty(path, context.Instance);
                    }
                }
            }

            // We don't have List of items
            if ((property == null) || (!(property is IList)))
            {
                base.DataList = null;
            }
            else
            {
                // Save the DataList
                base.DataList = property as IList;
            }
        }

        #endregion
    }

    public abstract class GridComboBox : UITypeEditor
    {
        #region Constants

        private const string StrAddNew = "<Add New...>";

        #endregion

        #region Data Members

        private IList _dataList;
        private readonly ListBox _listBox;
        private Boolean _escKeyPressed;
        private ListAttribute _listAttribute;
        private IWindowsFormsEditorService _editorService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public GridComboBox()
        {
            _listBox = new ListBox();

            // Properties
            _listBox.BorderStyle = BorderStyle.None;

            // Events
            _listBox.Click += myListBox_Click;
            _listBox.PreviewKeyDown += myListBox_PreviewKeyDown;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for ListBox
        /// </summary>
        protected ListBox ListBox
        {
            get { return (_listBox); }
        }

        /// <summary>
        /// Get/Set for DataList
        /// </summary>
        protected IList DataList
        {
            get { return (_dataList); }
            set { _dataList = value; }
        }

        /// <summary>
        /// Get/Set for ListAttribute
        /// </summary>
        protected ListAttribute ListAttribute
        {
            get { return (_listAttribute); }
            set { _listAttribute = value; }
        }

        #endregion

        #region Methods - Public

        /// <summary>
        /// Close DropDown window to finish editing
        /// </summary>
        public void CloseDropDownWindow()
        {
            if (_editorService != null)
                _editorService.CloseDropDown();
        }

        #endregion

        #region Methods - Private

        /// <summary>
        /// Populate the ListBox with data items
        /// </summary>
        /// <param name="context"></param>
        /// <param name="currentValue"></param>
        private void PopulateListBox(ITypeDescriptorContext context, Object currentValue)
        {
            // Clear List
            _listBox.Items.Clear();

            // Retrieve the reference to the items to be displayed in the list
            if (_dataList == null)
                RetrieveDataList(context);

            if (_dataList != null)
            {
                if ((_listAttribute is IAddNew) && (((IAddNew)_listAttribute).AddNew))
                    _listBox.Items.Add(StrAddNew);

                // Add Items to the ListBox
                foreach (object obj in _dataList)
                {
                    _listBox.Items.Add(obj);
                }

                // Select current item 
                if (currentValue != null)
                    _listBox.SelectedItem = currentValue;
            }

            // Set the height based on the Items in the ListBox
            _listBox.Height = _listBox.PreferredHeight;
        }

        #endregion

        #region Methods - Protected

        /// <summary>
        /// Get the object selected in the ComboBox
        /// </summary>
        /// <returns>Selected Object</returns>
        protected abstract object GetDataObjectSelected(ITypeDescriptorContext context);

        /// <summary>
        /// Find the list of data items to populate the ListBox
        /// </summary>
        /// <param name="context"></param>
        protected abstract void RetrieveDataList(ITypeDescriptorContext context);

        #endregion

        #region Event Handlers

        /// <summary>
        /// Preview Key Pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                _escKeyPressed = true;
        }

        /// <summary>
        /// ListBox Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListBox_Click(object sender, EventArgs e)
        {
            //when user clicks on an item, the edit process is done.
            this.CloseDropDownWindow();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context != null) && (provider != null))
            {
                //Uses the IWindowsFormsEditorService to display a 
                // drop-down UI in the Properties window:
                _editorService = provider.GetService(
                                     typeof(IWindowsFormsEditorService))
                                 as IWindowsFormsEditorService;

                if (_editorService != null)
                {
                    // Add Values to the ListBox
                    PopulateListBox(context, value);

                    // Set to false before showing the control
                    _escKeyPressed = false;

                    // Attach the ListBox to the DropDown Control
                    _editorService.DropDownControl(_listBox);

                    // User pressed the ESC key --> Return the Old Value
                    if (!_escKeyPressed)
                    {
                        // Get the Selected Object
                        object obj = GetDataObjectSelected(context);

                        // If an Object is Selected --> Return it
                        if (obj != null)
                            return (obj);
                    }
                }
            }

            return (value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return (UITypeEditorEditStyle.DropDown);
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class ListAttribute : Attribute
    {
    }

    public interface IAddNew
    {
        bool AddNew { get; }
    }

    public class DataListAttribute : ListAttribute, IAddNew
    {
        #region Data Members

        private readonly string _dllName;
        private readonly string _className;
        private readonly string _path;
        private readonly bool _isStatic;
        private readonly bool _addNew;
        private readonly string _eventHandler;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        public DataListAttribute(string path)
        {
            this._path = path;
            this._isStatic = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        /// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
        public DataListAttribute(string path, bool allowNew)
            : this(path)
        {
            this._addNew = allowNew;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        /// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
        /// <param name="eventHandler">On Add Callback Notification Method - Must be of type delegate ObjectAddedEventHandler</param>
        public DataListAttribute(string path, bool allowNew, string eventHandler)
            : this(path, allowNew)
        {
            this._eventHandler = eventHandler;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dllName">The name of the dll the class belongs to</param>
        /// <param name="className">The name of the class</param>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        public DataListAttribute(string dllName, string className, string path)
            : this(path)
        {
            this._isStatic = true;
            this._dllName = dllName;
            this._className = className;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dllName">The name of the dll the class belongs to</param>
        /// <param name="className">The name of the class</param>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        /// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
        public DataListAttribute(string dllName, string className, string path, bool allowNew)
            : this(dllName, className, path)
        {
            this._addNew = allowNew;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dllName">The name of the dll the class belongs to</param>
        /// <param name="className">The name of the class</param>
        /// <param name="path">Path to the list of items for display in the GridComboBox</param>
        /// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
        /// <param name="eventHandler">On Add Callback Notification Method - Must be of type delegate ObjectAddedEventHandler</param>
        public DataListAttribute(string dllName, string className, string path, bool allowNew, string eventHandler)
            : this(dllName, className, path, allowNew)
        {
            this._eventHandler = eventHandler;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for ClassName
        /// </summary>
        public string ClassName
        {
            get { return (_className); }
        }

        /// <summary>
        /// Get/Set for DllName
        /// </summary>
        public string DllName
        {
            get { return (_dllName); }
        }

        /// <summary>
        /// Get for Path
        /// </summary>
        public string Path
        {
            get { return (_path); }
        }

        /// <summary>
        /// Get for IsStatic
        /// </summary>
        public bool IsStatic
        {
            get { return (_isStatic); }
        }

        /// <summary>
        /// Get for AddNew
        /// </summary>
        public bool AddNew
        {
            get { return (_addNew); }
        }

        /// <summary>
        /// Get for EventHandler
        /// </summary>
        public string EventHandler
        {
            get { return (_eventHandler); }
        }

        #endregion
    }

    public static class Reflect
    {
        /// <summary>
        /// Create an instance of a class
        /// </summary>
        /// <param name="type">The type of class to instantiate</param>
        /// <param name="args">Arguments for the constructor</param>
        /// <returns>A class of the given type</returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            return type.InvokeMember(
                null,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.CreateInstance |
                BindingFlags.Instance,
                null,
                null,
                args);
        }


        /// <summary>
        /// Set a field/property of a class that has been instantiated
        /// </summary>
        /// <param name="classInstance">Class instantiation that contains the field/property to set the value</param>
        /// <param name="dataMemberName">The field/property name</param>
        /// <param name="value">The value to set in the field/property</param>
        public static void SetDataMember(object classInstance, string dataMemberName, object value)
        {
            object[] args = { value };

            classInstance.GetType().InvokeMember(
                dataMemberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.SetField |
                BindingFlags.SetProperty |
                BindingFlags.Instance,
                null,
                classInstance,
                args);
        }


        /// <summary>
        /// Set a static field/property of a class
        /// </summary>
        /// <param name="type">The class type</param>
        /// <param name="dataMemberName">The field/property name</param>
        /// <param name="value">The value to set in the field/property</param>
        public static void SetStaticDataMember(Type type, string dataMemberName, object value)
        {
            object[] args = { value };

            type.InvokeMember(
                dataMemberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.SetField |
                BindingFlags.SetProperty |
                BindingFlags.Static,
                null,
                null,
                args);
        }


        /// <summary>
        /// Get the value of a field/property from an instantiated class
        /// </summary>
        /// <param name="classInstance">Class instantiation from which to obtain the field/property value</param>
        /// <param name="dataMemberName">The field/property name</param>
        /// <returns>The value from the field/property</returns>
        public static object GetDataMember(object classInstance, string dataMemberName)
        {
            return classInstance.GetType().InvokeMember(
                dataMemberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetField |
                BindingFlags.GetProperty |
                BindingFlags.Instance,
                null,
                classInstance,
                null);
        }


        /// <summary>
        /// Get the value from a static field/property from a class
        /// </summary>
        /// <param name="type">The class type</param>
        /// <param name="dataMemberName">The field/property name</param>
        /// <returns>The value from the field/property</returns>
        public static object GetStaticDataMember(Type type, string dataMemberName)
        {
            return type.InvokeMember(
                dataMemberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetField |
                BindingFlags.GetProperty |
                BindingFlags.Static,
                null,
                null,
                null
                );
        }


        /// <summary>
        /// Call a method of a class instantiation
        /// </summary>
        /// <param name="classInstance">Class instantiation that contains the method to call</param>
        /// <param name="methodName">The name of the method</param>
        /// <param name="args">Arguments for the method</param>
        /// <returns>The value from the method call</returns>
        public static object CallMethod(object classInstance, string methodName, params object[] args)
        {
            return classInstance.GetType().InvokeMember(
                methodName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.InvokeMethod |
                BindingFlags.Instance,
                null,
                classInstance,
                args);
        }


        /// <summary>
        /// Call a static method of a class
        /// </summary>
        /// <param name="type">Class type that contains the method to call</param>
        /// <param name="memberName">The name of the method</param>
        /// <param name="args">Arguments for the method</param>
        /// <returns>The value from the method call</returns>
        public static object CallStaticMethod(Type type, string memberName, params object[] args)
        {
            return type.InvokeMember(
                memberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.InvokeMethod |
                BindingFlags.Static,
                null,
                null,
                args);
        }


        /// <summary>
        /// Call a field/property/method of a class instantiation
        /// </summary>
        /// <param name="classInstance">Class instantiation that contains the field/property/method to call</param>
        /// <param name="methodName">The name of the field/property/method</param>
        /// <param name="args">Arguments for the field/property/method</param>
        /// <returns>The value from the field/property/method call</returns>
        public static object CallGeneric(object classInstance, string methodName, params object[] args)
        {
            return classInstance.GetType().InvokeMember(
                methodName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetField |
                BindingFlags.GetProperty |
                BindingFlags.InvokeMethod |
                BindingFlags.Instance,
                null,
                classInstance,
                args);
        }


        /// <summary>
        /// Call a static field/property/method of a class
        /// </summary>
        /// <param name="type">Class type that contains the field/property/method to call</param>
        /// <param name="memberName">The name of the field/property/method</param>
        /// <param name="args">Arguments for the field/property/method</param>
        /// <returns>The value from the field/property/method call</returns>
        public static object CallStaticGeneric(Type type, string memberName, params object[] args)
        {
            return type.InvokeMember(
                memberName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetField |
                BindingFlags.GetProperty |
                BindingFlags.InvokeMethod |
                BindingFlags.Static,
                null,
                null,
                args);
        }
    }

    //public delegate void ObjectCreatedEventHandler(object sender, ObjectCreatedEventArgs arg);

    public class ObjectCreatedEventArgs : EventArgs
    {
        #region Data Members

        private readonly object _dataValue;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataValue"></param>
        public ObjectCreatedEventArgs(object dataValue)
        {
            this._dataValue = dataValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for DataValue
        /// </summary>
        public object DataValue
        {
            get { return (_dataValue); }
        }

        #endregion
    }

    public struct Property
    {
        #region Data Members

        private readonly object _index;
        private readonly string _name;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public Property(string name)
        {
            this._name = name;
            this._index = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        public Property(string name, object index)
            : this(name)
        {
            this._index = index;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get/Set for Index
        /// </summary>
        public object Index
        {
            get { return (_index); }
        }

        /// <summary>
        /// Get/Set for Name
        /// </summary>
        public string Name
        {
            get { return (_name); }
        }

        #endregion
    }

    public class PathParser
    {
        #region Methods - Public 

        /// <summary>
        /// Take a fully qualified path to a field/property/method and break it into the various segments
        /// </summary>
        /// <param name="path">Fully qualified path to a field/property/method - static or class instance</param>
        /// <returns>Array of the segments</returns>
        public static List<string> GetPathParts(string path)
        {
            List<string> parts = new List<string>();
            int length = path.Length;
            int startIndex = 0;
            int index;

            for (index = 0; index < length; index++)
            {
                if (path[index] == '[')
                {
                    char ch;
                    while ((ch = path[index]) != ']')
                    {
                        if (++index >= length)
                        {
                            ch = '\0';
                            break;
                        }
                    }

                    // Malformed string
                    if (ch != ']')
                        throw new FormatException("The path to the data is malformed");
                }
                else if (path[index] == '.')
                {
                    parts.Add(path.Substring(startIndex, (index - startIndex)));
                    startIndex = index + 1;
                }
            }

            // If we aren't at the end of the string - add the remaining information
            if (startIndex != (index - 1))
            {
                parts.Add(path.Substring(startIndex, (index - startIndex)));
            }

            return (parts);
        }


        /// <summary>
        /// Break a segment of a fully qualified path to a field/property, looking for array subscripting.
        /// </summary>
        /// <param name="variable">Segment of a fully qualified path to a field/property</param>
        /// <returns>A Property object containing the name of the field/property and the index if it exists</returns>
        public static Property BreakVariable(string variable)
        {
            Property property;
            string[] parts;

            parts = variable.Split(new char[] { '[', ']' });

            // No index subscript
            if (parts.Length == 1)
                property = new Property(parts[0]);
            else if (parts.Length == 3)
            {
                int index;

                // This is not an enumeration
                if (parts[1].IndexOf('.') == -1)
                {
                    // Is it a number
                    if (int.TryParse(parts[1], out index))
                        property = new Property(parts[0], index);
                    else
                    {
                        // Pass it through - probably a string
                        property = new Property(parts[0], parts[1]);
                    }
                }
                else
                {
                    // Enumeration
                    index = GetEnumValue(parts[1]);
                    property = new Property(parts[0], index);
                }
            }
            else
            {
                throw new FormatException("Invalid format: " + variable);
            }

            return (property);
        }

        /// <summary>
        /// Get the Enumeration value from a string
        /// </summary>
        /// <param name="enumString">String representation of an Enumeration</param>
        /// <returns>The integer value of the enumeration</returns>
        public static int GetEnumValue(string enumString)
        {
            string[] parts;
            string dll;
            string value;
            string className;

            parts = enumString.Split(new char[] { '.', ',' });

            if (parts.Length < 3)
            {
                throw new FormatException("Invalid format: " + enumString);
            }

            dll = parts[parts.Length - 1];
            value = parts[parts.Length - 2];
            className = string.Join(".", parts, 0, parts.Length - 2);

            Type enumClass = ClassType.GetType(dll, className);
            return ((int)Enum.Parse(enumClass, value));
        }

        #endregion
    }

    public static class ClassType
    {
        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="assemblyQualifiedName">Assembly-qualified name of the Type containing DLL, class name, version, culture, public key</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string assemblyQualifiedName)
        {
            return (Type.GetType(assemblyQualifiedName));
        }


        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="dllName">DLL where the class is defined</param>
        /// <param name="className">Fully qualified name of the class</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string dllName, string className)
        {
            string format = string.Format("{0}, {1}", className, dllName);
            return (GetType(format));
        }

        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="dllName">DLL where the class is defined</param>
        /// <param name="className">Fully qualified name of the class</param>
        /// <param name="version">The specific version to create</param>
        /// <param name="culture">The culture information</param>
        /// <param name="publicKeyToken">Public Key Token</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string dllName, string className, Version version, string culture, string publicKeyToken)
        {
            string format = string.Format("{0}, {1}, Version={2}, Culture={3}, PublicKeyToken={4}",
                className, dllName, version, culture, publicKeyToken);

            return (GetType(format));
        }
    }

    //public class ListExpandableConverter : ExpandableObjectConverter
    //{
    //    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
    //    {
    //        if (value is IDisplay)
    //            return (((IDisplay)value).Text);

    //        return (string.Empty);
    //    }
    //}

    //public interface IDisplay
    //{
    //    string Text { get; }
    //}
}
