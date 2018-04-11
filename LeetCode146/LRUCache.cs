using System;
using System.Collections.Generic;

namespace LeetCode146
{
    /// <summary>
    /// A performant LRUCache.
    /// </summary>
    /// <description> 
    /// *O(N^2) complexity is avoided.
    /// *Get and Set are O(1) but with memory expense of hash table.
    /// *No time component to avoid O(N^2) complexity
    /// </description>
    /// <remarks>
    /// On hash collisions, the most recent wins and loser evicted
    /// </remarks>
    public class LRUCache {
        //Prime Number TODO: Look into Prime Number generation 1000037
        private const uint HashSize = 10733;
        //Oversize Hash table to simplify problem 
        //TODO: JaggedArray or Array of LinkedList needed to handle hash collides
        private readonly KeyValuePair<LinkedListNode<uint>, int>[] valueMap;
        //Using a LinkedList to maintain order of keys
        private readonly LinkedList<uint> keyList;
        private readonly KeyValuePair<LinkedListNode<uint>, int> EmptyNode;

        private uint hashKey(uint key)
        {
            return key % HashSize;
        }

        private void AddKeyValueToHead(uint hashedKey, int value)
        {
            KeyValuePair<LinkedListNode<uint>,int> foundNode = 
                valueMap[hashedKey];

            if (foundNode.Key != null)
            {
                keyList.Remove(foundNode.Key);
            }

            foundNode = new KeyValuePair<LinkedListNode<uint>, int>(
                keyList.AddFirst(hashedKey), value);

            if (keyList.Count > Capacity)
            {
                valueMap[keyList.Last.Value] = EmptyNode;
                keyList.RemoveLast();
            }

            valueMap[hashedKey] = foundNode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeetCode146.LRUCache"/> class.
        /// </summary>
        /// <param name="capacity">Sets the size capacity of cache</param>
        public LRUCache(int capacity) 
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity needs to be a non-zero positive integer");
            }

            Capacity = capacity;
            valueMap = new KeyValuePair<LinkedListNode<uint>, int>[HashSize];
            keyList = new LinkedList<uint>();
            EmptyNode = new KeyValuePair<LinkedListNode<uint>, int>(null, -1);
        }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>The capacity of the LRUCache.</value>
        public int Capacity { get; private set; }

        /// <summary>
        /// Get the specified key and updates the LRUCache
        /// </summary>
        /// <param name="key">The Key to lookup on</param>
        /// <remarks>
        /// Key is added to head of a LinkedList to emulate
        /// some of the properties of having a time component.
        /// </remarks>
        public int Get(int key) 
        {
            uint hashedKey = hashKey((uint)key);

            if (valueMap[hashedKey].Key == null)
            {
                return -1;
            }

            AddKeyValueToHead(hashedKey, valueMap[hashedKey].Value);

            return valueMap[hashedKey].Value;
        }

        /// <summary>
        /// Put the specified key and value in cache
        /// </summary>
        /// <param name="key">The key to use for the corresponding value</param>
        /// <param name="value">The value to put into the cache</param>
        /// <remarks>
        /// Key is added to head of a LinkedList to emulate
        /// some of the properties of having a time component.
        /// </remarks>
        public void Put(int key, int value) 
        {
            AddKeyValueToHead(hashKey((uint)key), value);
        }
    }
}

