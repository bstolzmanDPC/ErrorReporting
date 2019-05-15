## ErrorReporting

This is a C# library that I developed to generate simple xml error reports to the users desktop. 

___

### Methods

<table>
  <tr>
    <td>
      <pre>Generate(Exception e)</pre>
    </td>
    <td>Generates an error file on the users Desktop that includes information about the passed exception. 
      Includes an XML data dump from the given object
      Returns path to the generated file as a string, or the exception message if it failed to generate the file.
    </td>
  </tr>
  <tr>
    <td>
      <pre>Generate<T>(Exception e, T obj)</pre>
    </td>
    <td>
      Overloaded to include object data dum in the report.
    </td>
  </tr>
    <tr>
    <td>
      <pre>LoadTestData<t>(string path)</pre>
    </td>
    <td>
      Data that is dumped in the error report can be placed into a separate xml file,
      and be loaded with this method to help reproduce the error with the data that was
      present at the time the error happened.
    </td>
  </tr>
  <tr>
    <td>
      <pre>ExportObj<T>(T obj, string name)</pre>
    </td>
    <td>
      This method helps to generate xml templates for classes. It will take a given object and export it in xml to the desktop
      with the name you provide.
    </td>
  </tr>
</table>
