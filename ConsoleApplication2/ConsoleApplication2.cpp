
//
//#include <iostream>
//#include <thread>
//using namespace std;
//void LaunchRocket()
//{
//	cout << "Launching Rocket" << endl;
//}
//int main()
//{
//	thread t1(LaunchRocket);
//	t1.join();
//	return 0;
//}


//#include <iostream>
//#include <thread>
//
//using namespace std;
//
//void LaunchRocket()
//{
//	cout << "Launching Rocket" << endl;
//}
//
//int main()
//{
//	thread t1(LaunchRocket);
//	//..... 100 строк какого-то кода
//	t1.join(); // CRASH !!!
//	return 0;
//}

//#include <iostream>
//#include <string>
//#include <thread>
//#include <mutex>
//
//using namespace std;
//
//std::mutex mu;
//
//void CallHome(string message)
//{ 
//	mu.lock();
//	cout << "Thread " << this_thread::get_id() << " says " << message << endl;
//	mu.unlock();
//}
//
//int main()
//{
//	thread t1(CallHome, "Hello from Jupiter");
//	thread t2(CallHome, "Hello from Pluto");
//	thread t3(CallHome, "Hello from Moon");
//
//	CallHome("Hello from Main/Earth");
//
//	thread t4(CallHome, "Hello from Uranus");
//	thread t5(CallHome, "Hello from Neptune");
//
//	t1.join();
//	t2.join();
//	t3.join();
//	t4.join();
//	t5.join();
//
//	return 0;
//}
//
//#include <iostream>
//#include <string>
//#include <thread>
//#include <mutex>
//
//using namespace std;
//
//std::mutex mu;
//
//void CallHome(string message)
//{
//	mu.lock();
//	cout << "Thread " << this_thread::get_id() << " says " << message << endl;
//	mu.unlock();
//}
//
//int main()
//{
//	thread t1(CallHome, "Hello from Jupiter");
//	thread t2(CallHome, "Hello from Pluto");
//	thread t3(CallHome, "Hello from Moon");
//
//	CallHome("Hello from Main/Earth");
//
//	thread t4(CallHome, "Hello from Uranus");
//	thread t5(CallHome, "Hello from Neptune");
//
//	t1.join();
//	t2.join();
//	t3.join();
//	t4.join();
//	t5.join();
//
//	return 0;
//}
//#include <iostream>
//#include <string>
//#include <thread>
//#include <mutex>
//
//using namespace std;
//
//std::mutex muA;
//std::mutex muB;

//void CallHome_Th1(string message)
//{
//	muA.lock();
//	// выполнение каких-то операций
//	std::this_thread::sleep_for(std::chrono::milliseconds(100));
//	muB.lock();
//
//	cout << "Thread " << this_thread::get_id() << " says " << message << endl;
//	muA.unlock();
//	muB.unlock();
//
//}
//
//void CallHome_Th2(string message)
//{
//	muA.lock();
//	// какие-то дополнительные операции
//	std::this_thread::sleep_for(std::chrono::milliseconds(100));
//	muB.lock();
//
//	cout << "Thread " << this_thread::get_id() << " says " << message << endl;
//
//	muA.unlock();
//	muB.unlock();
//}
//
//int main()
//{
//	thread t1(CallHome_Th1, "Hello from Jupiter");
//	thread t2(CallHome_Th2, "Hello from Pluto");
//
//	t1.join();
//	t2.join();
//
//	return 0;
//}
//
//#include <iostream>
//#include <thread>
//#include <mutex>
//
//std::mutex mu;
//
//static int counter = 0;
//
//void StartThruster()
//{
//	try
//	{
//		// какие-то операции
//	}
//	catch (...)
//	{
//		
//		std::cout << "Launching rocket" << std::endl;
//		
//	}
//}
//
//void LaunchRocket()
//{
//	std::lock_guard<std::mutex> lock(mu);
//	counter++;
//	StartThruster();
//}
//
//int main()
//{
//	std::thread t1(LaunchRocket);
//	t1.join();
//	return 0;
//}