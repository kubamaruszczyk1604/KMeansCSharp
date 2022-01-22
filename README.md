# C# implementation of k-means-clustering algorithm.

## Description

Algorithm operates on set of n-dimensional vectors (data points). 
These vectors are represented by DataVec class, which, in its simplest form contains:

  - Array of vector components
  - Method for calculating distance between data points: GetDistance(DataVec other). 

By default, euclidean distance is used, but classes that inherit form DataVec can provide their own distance function 
by overriding GetDistance() method.


### Example usage:

    //Data points
  
    List<DataVec> points = ReadTestData();
  
    // First argument of the constructor is a reference to data points. Second argument is k (number of clusters)
  
    KMeansClustering cl = new KMeansClustering(points.ToArray(), 15);
  
    // Perform clasification and return results
  
    Cluster[] clusters =  cl.Calculate();
  

Each returned Cluster object will contain:
  
  - Centroid Point (mean of all points in this cluster)
  - List of all points that are members of this cluster.

## Disclaimer
This software was tested with few datasets and gives results that are close to ground truth.
I also use it for extracting palettes from images, with satisfying results.
However, I cannot guarantee it is 100% bug free.
If you find any part of it useful, feel free to use it however you like.
