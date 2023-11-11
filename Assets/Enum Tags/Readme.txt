Enum Tags is a simple script that mirrors Unity's tags to a static class that is automatically generated
and all the tags are added as properties for easier access in code.

How to:
1. Import the package
2. To use just type "Tags." and all your tags will be shown in autocomplete
Example: CompareTag(Tags.YourTagName)

Quirks: 
1. Special characters like @*& etc. will be shown as SC (Special Character) in the tag autocomplete
because the tags are stored as properties and special characters are not allowed. However this doesn't affect
tag comparison.
2. Make sure you have write permissions for the Enum Tags folder or the script wouldn't be able to update the tags.