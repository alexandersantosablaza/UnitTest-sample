namespace unit;

public class TodoListTests
{
    private readonly TodoList list = new();
    [Fact]
    public void TodoList_AddTodoItem()
    {
        //arrange
        string content = "I am going to code unit test";
        TodoList.TodoItem item = new(Content: content);
        //act
        list.Add(item);
        //assert
        var saveItem = Assert.Single(list.All);
        Assert.NotNull(saveItem);
        Assert.Equal(1, saveItem.Id);
        Assert.Equal(content, saveItem.Content);
        Assert.False(saveItem.Complete);
    }
    [Fact]
    public void TodoItemIDIncrementsEveryItemAdd()
    {
        //arrange
        //act
        list.Add(new("Test 1"));
        list.Add(new("Test 2"));
        //assert
        TodoList.TodoItem[] items = [.. list.All];
        Assert.Equal(1, items[0].Id);
        Assert.Equal(2, items[1].Id);
    }
    [Fact]
    public void TodoItem_SetsCompletesTrue()
    {
        //arrange
        list.Add(new("Test 2"));
        //act
        list.Complete(1);
        //assert
        var completedItem = Assert.Single(list.All);
        Assert.NotNull(completedItem);
        Assert.Equal(1, completedItem.Id);
        Assert.True(completedItem.Complete);
    }
}