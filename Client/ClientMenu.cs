using Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class ClientMenu
    {
        public static void Main()
        {
            Client client = new Client();
            Sensor sensor = new Sensor();
            Measurement measurement = new Measurement();

            sensor.AddMeasurement(measurement);
            client.SensorData = sensor;

            while (true)
            {
                Console.WriteLine("Press:\n\t- 1) Start client\n\t- 2) Modify.\n");
                string input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    client.Start();
                }
                else if (input.Equals("2"))
                {
                    while (true)
                    {
                        Console.WriteLine("Press:\n\t- 1) to set Server IP\n\t- 2) to set your ID.\n\t" +
                        " -3) to set Type of measurement.\n\t- 4) to go back to the main menu.");
                        Console.Write("Your choice: ");
                        input = Console.ReadLine();
                        if (input.Equals("1"))
                        {
                            Console.Write("IP to connect: ");
                            string ip = Console.ReadLine();
                            string[] tmp = ip.Split(".");
                            if (tmp.Length != 4)
                            {
                                throw new Exception("NotValidIP");
                            }


                            try
                            {
                                foreach (var item in tmp)
                                {
                                    byte.Parse(item);
                                }
                            }
                            catch
                            {
                                throw new Exception("NotValidAttributes");
                            }

                            client.ServerIPAddress = new byte[] { byte.Parse(tmp[0]),
                                byte.Parse(tmp[1]), byte.Parse(tmp[2]), byte.Parse(tmp[3]) };
                        }

                        else if (input.Equals("2"))
                        {
                            Console.Write("Your ID: ");
                            input = Console.ReadLine();
                            sensor.ID = input;
                        }
                        else if (input.Equals("3"))
                        {
                            Console.WriteLine("\n\tPress:\n\t\t- 1) for celsius.\n\t\t" +
                                "- 2) for humidity.\n\t\t- 3) for air pressure.");
                            input = Console.ReadLine();
                            Random random = new Random();
                            if (input.Equals("1"))
                            {
                                sensor.MeasurementOfSensor.MeasurementType = "Celsius";
                                sensor.MeasurementOfSensor.Value = random.Next(-20, 40).ToString();
                            }
                            else if (input.Equals("2"))
                            {
                                sensor.MeasurementOfSensor.MeasurementType = "Humidity";
                                sensor.MeasurementOfSensor.Value = random.Next(0, 90).ToString();
                            }
                            else if (input.Equals("3"))
                            {
                                sensor.MeasurementOfSensor.MeasurementType = "Air pressure";
                                sensor.MeasurementOfSensor.Value = random.Next(0, 3000).ToString();
                            }
                            else
                                throw new Exception("InvalidInput");
                        }
                        else if (input.Equals("4"))
                        {
                            break;
                        }
                    }
                }
                else
                    throw new Exception("InvalidInput!");
            }
        }
    }
}
