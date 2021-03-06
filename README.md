# C# implementation of k-means-clustering algorithm.
To keep things simple and easy to port to other languages, no C#-specific features, nor libaries (such as Linq) were used: except for Collections.Generic.List, which could be easily replaced with any resizable container type, e.g. std::vector in C++.

## Description

Algorithm operates on set of n-dimensional vectors (data points). 
These vectors are represented by DataVec class, which, in its simplest form contains:

  - Array of vector components
  - Method for calculating distance between data points: GetDistance(DataVec other). 

By default, euclidean distance is used, but since algorithm only cares about the distance function (and not about the underlying data structure), 
classes that are derived form DataVec can provide their own implemantations of distance function via override of default GetDistance() method.

### Example usage:

    //Data points
    List<DataVec> points = ReadTestData();
  
    // First argument of the constructor is a reference to data points. Second argument is k (number of clusters)
    KMeansClustering cl = new KMeansClustering(points.ToArray(), 15);
  
    // Perform clasification and return results
    Cluster[] clusters =  cl.Compute();
  

Each returned Cluster object will contain:
  
  - Centroid Point (mean of all points in this cluster)
  - List of all points that were assigned this cluster.

## Disclaimer
This code was tested with few datasets and gives results that are close to ground truth.
It also works fine for image posterization and colour paletes extraction (although it is quite slow for larger images and higher k's).
I cannot, however, guarantee that it is 100% bug free.
If you find any part of it useful, feel free to use it however you like.
