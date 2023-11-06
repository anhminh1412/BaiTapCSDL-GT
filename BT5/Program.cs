using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4
{
	internal class Program
	{
		public class Node
		{
			public int Data { get; set; }
			public Node Next { get; set; }
		}

		public class MyList
		{
			private Node head;
			private Node tail;

			public int Count { get; private set; }

			public MyList()
			{
				head = null;
				tail = null;
				Count = 0;
			}

			public void AddFirst(int x)
			{
				Node newNode = new Node { Data = x };
				if (head == null)
				{
					head = newNode;
					tail = newNode;
				}
				else
				{
					newNode.Next = head;
					head = newNode;
				}
				Count++;
			}

			public void AddLast(int x)
			{
				Node newNode = new Node { Data = x };
				if (head == null)
				{
					head = newNode;
					tail = newNode;
				}
				else
				{
					tail.Next = newNode;
					tail = newNode;
				}
				Count++;
			}

			public void ShowList()
			{
				Node current = head;
				while (current != null)
				{
					Console.Write(current.Data + " ");
					current = current.Next;
				}
				Console.WriteLine();
			}

			public Node SearchX(int x)
			{
				Node current = head;
				while (current != null)
				{
					if (current.Data == x)
						return current;
					current = current.Next;
				}
				return null;
			}

			public Node GetMax()
			{
				Node current = head;
				Node maxNode = current;
				while (current != null)
				{
					if (current.Data > maxNode.Data)
						maxNode = current;
					current = current.Next;
				}
				return maxNode;
			}

			public Node GetMin()
			{
				Node current = head;
				Node minNode = current;
				while (current != null)
				{
					if (current.Data < minNode.Data)
						minNode = current;
					current = current.Next;
				}
				return minNode;
			}

			public MyList GetEvenList()
			{
				MyList evenList = new MyList();
				Node current = head;
				while (current != null)
				{
					if (current.Data % 2 == 0)
						evenList.AddLast(current.Data);
					current = current.Next;
				}
				return evenList;
			}

			public MyList GetOddList()
			{
				MyList oddList = new MyList();
				Node current = head;
				while (current != null)
				{
					if (current.Data % 2 != 0)
						oddList.AddLast(current.Data);
					current = current.Next;
				}
				return oddList;
			}
			public void Input()
			{
				Console.WriteLine("Enter the number of elements:");
				int n = Convert.ToInt32(Console.ReadLine());
				for (int i = 0; i < n; i++)
				{
					Console.WriteLine("Enter element " + (i + 1) + ":");
					int x = Convert.ToInt32(Console.ReadLine());
					this.AddLast(x);
				}
			}

			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


			public void RemoveAt(int i)
			{
				if (i < 0 || i >= Count)
				{
					throw new IndexOutOfRangeException();
				}

				if (i == 0)
				{
					head = head.Next;
					if (head == null)
					{
						tail = null;
					}
				}
				else
				{
					Node current = head;
					for (int j = 0; j < i - 1; j++)
					{
						current = current.Next;
					}

					current.Next = current.Next.Next;

					if (current.Next == null)
					{
						tail = current;
					}
				}

				Count--;
			}
			public void RemoveX(int x)
			{
				Node current = head;
				Node previous = null;

				while (current != null)
				{
					if (current.Data == x)
					{
						if (previous == null)
						{
							head = current.Next;
							if (head == null)
							{
								tail = null;
							}
						}
						else
						{
							previous.Next = current.Next;
							if (current.Next == null)
							{
								tail = previous;
							}
						}

						Count--;
						return;
					}

					previous = current;
					current = current.Next;
				}
			}
			public void InsertAt(int x, int i)
			{
				if (i < 0 || i > Count)
				{
					throw new IndexOutOfRangeException();
				}

				Node newNode = new Node { Data = x };

				if (i == 0)
				{
					newNode.Next = head;
					head = newNode;

					if (tail == null)
					{
						tail = newNode;
					}
				}
				else
				{
					Node current = head;
					for (int j = 0; j < i - 1; j++)
					{
						current = current.Next;
					}

					newNode.Next = current.Next;
					current.Next = newNode;

					if (newNode.Next == null)
					{
						tail = newNode;
					}
				}

				Count++;
			}
			public void InsertXAfterMin(int x)
			{
				Node minNode = GetMin();

				Node newNode = new Node { Data = x };
				newNode.Next = minNode.Next;
				minNode.Next = newNode;

				if (newNode.Next == null)
				{
					tail = newNode;
				}

				Count++;
			}
			public void InsertXAfterY(int x, int y)
			{
				Node yNode = SearchX(y);

				if (yNode == null)
				{
					throw new ArgumentException("Value y not found in the list.");
				}

				Node newNode = new Node { Data = x };
			}
			public void InsertXBeforeMax(int x)
			{
				Node maxNode = GetMax();
				Node newNode = new Node { Data = x };

				if (head == maxNode)
				{
					newNode.Next = head;
					head = newNode;
				}
				else
				{
					Node current = head;
					while (current.Next != maxNode)
					{
						current = current.Next;
					}

					newNode.Next = current.Next;
					current.Next = newNode;
				}

				Count++;
			}
			public void InsertXBeforeY(int x, int y)
			{
				Node yNode = SearchX(y);
				Node newNode = new Node { Data = x };

				if (head == yNode)
				{
					newNode.Next = head;
					head = newNode;
				}
				else
				{
					Node current = head;
					while (current.Next != yNode)
					{
						current = current.Next;
					}

					newNode.Next = current.Next;
					current.Next = newNode;
				}

				Count++;
			}
			public void RShiftRight()
			{
				if (head == null || head == tail)
				{
					return;
				}

				Node current = head;
				while (current.Next != tail)
				{
					current = current.Next;
				}

				tail.Next = head;
				head = tail;
				tail = current;
				tail.Next = null;
			}
			public void InterchangeSort()
			{
				for (Node i = head; i != null; i = i.Next)
				{
					for (Node j = i.Next; j != null; j = j.Next)
					{
						if (i.Data > j.Data)
						{
							int temp = i.Data;
							i.Data = j.Data;
							j.Data = temp;
						}
					}
				}
			}
			public void SelectionSort()
			{
				for (Node i = head; i != null; i = i.Next)
				{
					Node maxNode = i;

					for (Node j = i.Next; j != null; j = j.Next)
					{
						if (j.Data > maxNode.Data)
						{
							maxNode = j;
						}
					}

					if (maxNode != i)
					{
						int temp = i.Data;
						i.Data = maxNode.Data;
						maxNode.Data = temp;
					}
				}
			}
		}
		


		static void Main(string[] args)
		{
			MyList myList = new MyList();
			int choice, x, y;
			Node node;
			do
			{
				Console.OutputEncoding = Encoding.UTF8;
				Console.WriteLine("\nMENU");
				Console.WriteLine("1. Thêm một node vào đầu danh sách");
				Console.WriteLine("2. Thêm một node vào cuối danh sách");
				Console.WriteLine("3. Nhập các giá trị vào danh sách");
				Console.WriteLine("4. Hiển thị danh sách");
				Console.WriteLine("5. Tìm kiếm một node với giá trị cho trước");
				Console.WriteLine("6. Lấy node có giá trị lớn nhất");
				Console.WriteLine("7. Lấy node có giá trị nhỏ nhất");
				Console.WriteLine("8. Lấy danh sách mới chỉ chứa số chẵn");
				Console.WriteLine("9. Lấy danh sách mới chỉ chứa số lẻ");
				Console.WriteLine("10. Xóa node tại vị trí thứ i");
				Console.WriteLine("11. Xóa node có giá trị x");
				Console.WriteLine("12. Chèn x vào danh sách tại vị trí thứ i");
				Console.WriteLine("13. Chèn x vào sau node có giá trị nhỏ nhất");
				Console.WriteLine("14. Chèn x vào sau node có giá trị y");
				Console.WriteLine("15. Chèn x vào trước node có giá trị lớn nhất");
				Console.WriteLine("16. Chèn x vào trước node có giá trị y");
				Console.WriteLine("17. Dịch phải xoay vòng danh sách");
				Console.WriteLine("18. Sắp xếp danh sách theo thứ tự tăng dần (Interchange sort)");
				Console.WriteLine("19. Sắp xếp danh sách theo thứ tự giảm dần (Selection sort)");
				Console.WriteLine("20. Thoát");

				Console.Write("\nNhập lựa chọn của bạn: ");
				choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("\nNhập giá trị để thêm: ");
						x = Convert.ToInt32(Console.ReadLine());
						myList.AddFirst(x);
						break;

					case 2:
						Console.Write("\nNhập giá trị để thêm: ");
						x = Convert.ToInt32(Console.ReadLine());
						myList.AddLast(x);
						break;

					case 3:
						myList.Input();
						break;

					case 4:
						myList.ShowList();
						break;

					case 5:
						Console.Write("\nNhập giá trị để tìm kiếm: ");
						x = Convert.ToInt32(Console.ReadLine());
						node = myList.SearchX(x);
						if (node == null)
							Console.WriteLine("Không tìm thấy node.");
						else
							Console.WriteLine("Tìm thấy node.");
						break;

					case 6:
						node = myList.GetMax();
						if (node == null)
							Console.WriteLine("Danh sách rỗng.");
						else
							Console.WriteLine("Giá trị lớn nhất là " + node.Data);
						break;

					case 7:
						node = myList.GetMin();
						if (node == null)
							Console.WriteLine("Danh sách rỗng.");
						else
							Console.WriteLine("Giá trị nhỏ nhất là " + node.Data);
						break;

					case 8:
						MyList evenList = myList.GetEvenList();
						evenList.ShowList();
						break;

					case 9:
						MyList oddList = myList.GetOddList();
						oddList.ShowList();
						break;

					case 10:
						Console.Write("\nNhập vị trí để xóa: ");
						int i = Convert.ToInt32(Console.ReadLine());
						myList.RemoveAt(i);
						break;

					case 11:
						Console.Write("\nNhập giá trị để xóa: ");
						x = Convert.ToInt32(Console.ReadLine());
						myList.RemoveX(x);
						break;

					case 12:
						Console.Write("\nNhập giá trị để chèn: ");
						x = Convert.ToInt32(Console.ReadLine());
						Console.Write("\nNhập vị trí để chèn: ");
						i = Convert.ToInt32(Console.ReadLine());
						myList.InsertAt(x, i);
						break;

					case 13:
						Console.Write("\nNhập giá trị để chèn sau min: ");
						x = Convert.ToInt32(Console.ReadLine());
						myList.InsertXAfterMin(x);
						break;

					case 14:
						Console.Write("\nNhập giá trị x để chèn: ");
						x = Convert.ToInt32(Console.ReadLine());
						Console.Write("\nNhập giá trị y để chèn sau: ");
						y = Convert.ToInt32(Console.ReadLine());
						myList.InsertXAfterY(x, y);
						break;

					case 15:
						Console.Write("\nNhập giá trị để chèn trước max: ");
						x = Convert.ToInt32(Console.ReadLine());
						myList.InsertXBeforeMax(x);
						break;

					case 16:
						Console.Write("\nNhập giá trị x để chèn: ");
						x = Convert.ToInt32(Console.ReadLine());
						Console.Write("\nNhập giá trị y để chèn trước: ");
						y = Convert.ToInt32(Console.ReadLine());
						myList.InsertXBeforeY(x, y);
						break;

					case 17:
						myList.RShiftRight();
						break;

					case 18:
						myList.InterchangeSort();
						break;

					case 19:
						myList.SelectionSort();
						break;

					case 20:
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("\nLựa chọn không hợp lệ. Vui lòng thử lại.");
						break;
				}
			} while (true);
		}

	}
}

