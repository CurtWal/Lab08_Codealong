using System.Collections.Generic;
using System.Collections;

namespace LendingLibrary.Classes{
     public interface IBag<T> : IEnumerable<T>
 {
     /// <summary>
     /// Add an item to the bag. <c>null</c> items are ignored.
     /// </summary>
     void Pack(T item);

     /// <summary>
     /// Remove the item from the bag at the given index.
     /// </summary>
     /// <returns>The item that was removed.</returns>
     T Unpack(int index);
 }
 //create a backpack list class
 public class BackPack<T> : IBag<T>{
    private readonly List<T> stuff = new List<T>(); //create a new list object of stuff

    public void Pack(T item){
        stuff.Add(item); // add an item to our backpack
    }

    public T Unpack(int index){
        //find the thing we want to unpack in our list object
        T thing = stuff[index];
        stuff.RemoveAt(index); //Method to remove items by index
        return thing; // returning what was unpacked
    }
    public IEnumerator<T> GetEnumerator(){
        foreach(T thing in stuff)
        yield return thing;
    }
    IEnumerator IEnumerable.GetEnumerator(){
        return GetEnumerator();
    }
 }
}