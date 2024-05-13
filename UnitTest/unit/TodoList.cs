namespace unit;

internal class TodoList
{
    public record TodoItem(string Content)
    {
        public int Id { get; init; }
        public bool Complete { get; init; }
    }
    private readonly List<TodoItem> _todoItems = [];
    private int counter = 1;
    public void Add(TodoItem item)
    {
        _todoItems.Add(item with { Id = counter++ });
    }
    public IEnumerable<TodoItem> All => _todoItems;
    public void Complete(int id)
    {
        var item = _todoItems.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {

            int itemId = _todoItems.IndexOf(item);
            var completedItem = item with { Complete = true };
            _todoItems[itemId] = completedItem;
        }
    }
}
