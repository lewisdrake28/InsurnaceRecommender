using System;
using System.Numerics;

namespace Code
{
    class Program
    {
        static int FindAgeAngle(int age)
        {
            double lower1 = 17;
            double upper1 = 25;
            double lower2 = 26;
            double upper2 = 70;
            double lower3 = 71;
            double upper3 = 100;

            if (age > upper3)
            {
                age = (int)upper3;
            }

            if (age >= lower1 && age <= upper1)
            {
                double percentage = 1 - (age - lower1 + 1) / (upper1 - lower1 + 1);
                double angle = 180 * percentage + 180;

                return CheckAngle((int)angle);
            }
            else if (age >= lower2 && age <= upper2)
            {
                double peak = (lower2 + upper2) / 2;

                if (age < peak)
                {
                    double percentage = 1 - (age - lower2 + 1) / (peak - lower2 + 1);
                    double angle = 180 * percentage;

                    return CheckAngle((int)angle);
                }
                else
                {
                    double percentage = (age - peak + 1) / (upper2 - peak + 1);
                    double angle = 180 * percentage;

                    return CheckAngle((int)angle);
                }
            }
            else if (age >= lower3 && age <= upper3)
            {
                double percentage = (age - lower3 + 1) / (upper3 - lower3 + 1);
                double angle = 180 * percentage + 180;

                return CheckAngle((int)angle);
            }

            return -1;
        }

        static int FindParkedAngle(int index, int maxIndex)
        {
            double interval = 360 / (double)maxIndex;

            double angle = index * interval;

            return CheckAngle((int)angle);
        }

        static int FindPointsAngle(int points)
        {
            double max = 12;

            double percentage = (double)points / (max + 1);
            double angle = percentage * 360;

            return CheckAngle((int)angle);
        }

        static int FindMileageAngle(int miles)
        {
            double min = 200;
            double max = 99999;

            if (miles > max)
            {
                miles = (int)max;
            }
            else if (miles < min)
            {
                miles = (int)min;
            }

            double percentage = (double)(miles - min) / (max - min);
            double angle = percentage * 360;

            return CheckAngle((int)angle);
        }

        static int FindExcessAngle(int excess)
        {
            double max = 1000;

            if (excess > max)
            {
                excess = (int)max;
            }

            double percentage = 1 - (double)excess / max;
            double angle = percentage * 360;

            return CheckAngle((int)angle);
        }

        static int FindModifiedAngle(bool modified)
        {
            if (modified)
            {
                return 270;
            }

            return 90;
        }

        static int FindExperienceAngle(int experience)
        {
            double mid = 5;
            
            if (experience > 100)
            {
                experience = 100;
            }

            if (experience <= mid)
            {
                double percentage = 1 - (double)(experience) / (mid);
                double angle = percentage * 90 + 269;

                return CheckAngle((int)angle);
            }
            else
            {
                double percentage = (double)(experience - mid) / (100 - mid);
                double angle = percentage * 270 + 90;

                return CheckAngle((int)angle);
            }
        }

        static int CheckAngle(int angle)
        {
            if (angle > 359)
            {
                angle = 359;
            }

            return angle;
        }

        static double[] CreateVector(int angle)
        {
            double[] vector = new double[2];
            double radians = angle * (Math.PI / 180);

            vector[0] = Math.Cos(radians);
            vector[1] = Math.Sin(radians);

            return vector;
        }

        static double[] CombineVectors(int[] angles)
        {
            double[] vector = new double[3];
            int sum = 0;

            for (int a = 0; a < angles.Length; a++)
            {
                sum += angles[a];
            }

            double angle = (double)sum / (double)angles.Length;
            vector[0] = CreateVector((int)angle)[0];
            vector[1] = CreateVector((int)angle)[1];
            vector[2] = angle;

            return vector;
        }

        static int[] GetResults()
        {
            int[] angles = new int[7];
            int a;

            do
            {
                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter age in numerical form");
                }
                else if (a < 17)
                {
                    Console.WriteLine("Age must be greater than 17");
                }
                else
                {
                    angles[0] = FindAgeAngle(a);

                    break;
                }
            } while (true);

            do
            {
                Console.WriteLine("1: locked garage 2: secure car park 3: driveway 4: residential car park 5: street");
                Console.Write("Index: ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter index in numerical form");
                }
                else if (a < 1)
                {
                    Console.WriteLine("Index must be greater than 0 and less than 6");
                }
                else if (a > 6)
                {
                    Console.WriteLine("Index must be greater than 0 and less than 6");
                }
                else
                {
                    a--;
                    angles[1] = FindParkedAngle(a, 5);

                    break;
                }
            } while (true);

            do
            {
                Console.Write("Points: ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter points in numerical form");
                }
                else if (a < -1 || a > 13)
                {
                    Console.WriteLine("Points must be greater than -1 and less than 13");
                }
                else
                {
                    angles[2] = FindPointsAngle(a);

                    break;
                }
            } while (true);

            do
            {
                Console.Write("Mileage: ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter mileage in numerical form");
                }
                else if (a < 0)
                {
                    Console.WriteLine("Mileage must be greater than 0");
                }
                else
                {
                    angles[3] = FindMileageAngle(a);

                    break;
                }
            } while (true);

            do
            {
                Console.Write("Excess (£): ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter excess in numerical form");
                }
                else if (a < -1)
                {
                    Console.WriteLine("Points must be greater than -1");
                }
                else
                {
                    angles[4] = FindExcessAngle(a);

                    break;
                }
            } while (true);

            do
            {
                Console.Write("Modified (Y or N): ");
                string? choice = Console.ReadLine();
                if (choice != null)
                {
                    choice = choice.ToUpper();
                    if (choice == "Y")
                    {
                        angles[5] = FindModifiedAngle(true);

                        break;
                    }
                    else if (choice == "N")
                    {
                        angles[5] = FindModifiedAngle(false);

                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Error, enter either Y or N");
                    }
                }
            } while (true);

            do
            {
                Console.Write("Experience (years): ");
                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter experience in numerical form");
                }
                else if (a < -1)
                {
                    Console.WriteLine("Experience must be greater than -1");
                }
                else
                {
                    angles[6] = FindExperienceAngle(a);

                    break;
                }
            } while (true);

            return angles;
        }
        
        static void Main(string[] args)
        {
            int a;
            int[] angles = GetResults();
            double[] vector = CombineVectors(angles);

            do
            {
                Console.WriteLine("1: Third party only  2: Third party, fire and theft  3: Fully comprehensive");
                Console.Write("Index: ");

                if (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Error, enter index in numerical form");
                }
                else if (a < 1)
                {
                    Console.WriteLine("Index must be greater than 0");
                }
                else if (a > 3)
                {
                    Console.WriteLine("Index must be less than 4");
                }
                else
                {
                    break;
                }
            } while (true);

            double avergae = 650;
            double percentage = vector[2] / 360 * 2;
            double cost = avergae * percentage + (avergae / 2);
            cost = Math.Round(cost, 2);

            if (a == 2)
            {
                cost = cost * 1.25;
            }
            else if (a == 3)
            {
                cost = cost * 1.5;
            }

            Console.WriteLine("\nInsurnace quoted at £" + cost);
        }
    }
}
